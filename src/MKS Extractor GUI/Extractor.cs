using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MKS_Extractor_GUI
{
    class Extractor
    {
        //This variable contains the information whether a process is currently running.
        private Boolean done = true;

        //This variable contains information on the progress of the currently running process. 100 is the target value.
        private int progress = 0;

        public bool Done { get => done; set => done = value; }
        public int Progress { get => progress; set => progress = value; }

        private MKVJson Deserialize(string pFile, string pMkvMerge)
        {
            String json;

            //Create new process
            Process process = new Process();
            process.StartInfo.FileName = pMkvMerge + "mkvmerge.exe";
            process.StartInfo.Arguments = "-J \"" + pFile + "\"";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            //Get JSON information
            try
            {
                process.Start();
                json = process.StandardOutput.ReadToEnd();
            }
            catch
            {
                return null;
            }

            //Deserialize
            return JsonConvert.DeserializeObject<MKVJson>(json);
        }

        private List<int> ListFilteredTracks(List<MKVJson.Track> pTracks, List<string> pLanguages)
        {
            List<int> temp_filtered = new List<int>();

            //Iterate through all tracks
            foreach (MKVJson.Track o in pTracks)
            {
                //Filter subtitle tracks
                if (o.Type == "subtitles")
                {
                    //Filter track with specified languages
                    if (pLanguages.Contains(o.Properties.Language))
                    {
                        //Add filtered track id to temp list
                        temp_filtered.Add(o.Id);
                    }
                }
            }
            return temp_filtered;
        }

        //Generate string for -s, --subtitle-tracks <n,m,…>
        private string FormatSubtitleTracks(List<int> pTrackID)
        {
            string temp = "";
            foreach (int o in pTrackID) { temp += o + ","; }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }

        //Generate string for --track-order <FileID1:TID1,FileID2:TID2,FileID3:TID3,…>
        private string FormatTrackOrder(List<int> pTrackID)
        {
            string temp = "";
            foreach (int o in pTrackID) { temp += "0:" + o + ","; }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }

        //Generate string for --language <TID:Language>
        private string FormatLanguages(List<int> pTrackID, List<MKVJson.Track> pTracks)
        {
            string temp = "";
            foreach (int o in pTrackID) { temp += "--language " + o + ":" + pTracks[o].Properties.Language + " "; }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }

        private void StartMergeProcess(string pMkvMerge, string pFile, string pSubtitleTracks, string pLanguages, string pTrackOrder)
        {

            Done = false;

            //Create new process
            Process process = new Process();
            process.StartInfo.FileName = pMkvMerge + "mkvmerge.exe";
            process.StartInfo.Arguments = "-J \"" + pFile + "\"";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;

            //Eventhandler
            process.Exited += ExitEvent;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);

            //Run the extraction process
            process.StartInfo.Arguments = "--ui-language en --output \"" + pFile.Substring(0, pFile.ToString().Length - 4) + ".mks\" -A -D -s " + pSubtitleTracks + " --no-chapters " + pLanguages + " \"" + pFile + "\" --track-order " + pTrackOrder;
            try
            {
                process.Start();
                process.BeginOutputReadLine();
            }
            catch
            {
                //Could add more error feedback
            }
        }

        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            //This should be replaced in the future with a more sophisticated method.
            if (outLine.Data != null)
            {
                if(outLine.Data.Contains("Progress: "))
                {
                    string temp = outLine.Data.Replace("Progress: ", "");
                    temp = temp.Substring(0, temp.Length - 1);
                    Int32.TryParse(temp, out progress);
                }
                else
                {
                    progress = 0;
                }
            }
        }

        private void ExitEvent(object sender, EventArgs e)
        {
            Exiting();
        }

        private void Exiting()
        {
            Done = true;
        }


        //Wrapper for the main extraction
        public void Execute(string pMkvMerge, string pFile, List<string> pLanguages)
        {
            MKVJson mkv = Deserialize(pFile, pMkvMerge);

            //Check if an extraction process is still running
            if (Done == true)
            {
                //Check if mkv deserialize was successful
                if (mkv != null && mkv.Errors.Count == 0)
                {
                    //Check if a subtitle track exist
                    List<int> tempFilteredTracks = ListFilteredTracks(mkv.Tracks, pLanguages);
                    if (tempFilteredTracks.Count > 0)
                    {
                        StartMergeProcess(pMkvMerge, pFile, FormatSubtitleTracks(tempFilteredTracks), FormatLanguages(tempFilteredTracks, mkv.Tracks), FormatTrackOrder(tempFilteredTracks));
                    }
                    else
                    {
                        //No subitle track found. Exit.
                        Exiting();
                    }

                }
            }

        }

        //Check if MKVToolNix is working
        public Boolean CheckMkvToolNix(string pMkvMerge)
        {
            //Create new process
            Process process = new Process();
            process.StartInfo.FileName = pMkvMerge + "mkvmerge.exe";
            process.StartInfo.Arguments = "-V";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;

            try
            {
                process.Start();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
