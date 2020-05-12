using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MKS_Extractor_GUI
{
    public partial class MainForm : Form
    {

        // ### MAIN FORM ###

        string messageBoxTitle = "MKS Extractor GUI";

        Boolean exitRequest = false;

        Extractor job = new Extractor();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Enter default values
            textBox_toolnix_path.Text = @"C:\Program Files\MKVToolNix\";
            listBox_languages.Items.Add("eng");

            //Settings for the statusStrip
            statusStrip.Renderer = new StatusStripRenderer();
            toolStripStatusLabel_current.Spring = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Ask if the user really wants to close the window
            if (job.Done == false)
            {
                if (MessageBox.Show("An extraction job is still running. Do you really want to exit MKS Extractor GUI? The process will continue in the background.", messageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }



        // ### MKVToolNix GROUP ###

        //MKVToolNix folder browser
        private void button_toolnix_browse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox_toolnix_path.Text = fbd.SelectedPath;
                }
            }
        }



        // ### MKV GROUP ###

        //Enable drag&drop for the mkv list
        private void listBox_mkvlist_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        //Handling file drops
        private void listBox_mkvlist_DragDrop(object sender, DragEventArgs e)
        {
            string[] dropped = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in dropped)
            {
                //Check if the dropped file is a mkv file
                if (System.IO.Path.GetExtension(file).ToUpperInvariant() == ".MKV")
                {
                    //Check if the file already exists in the mkv list
                    if (listBox_mkvlist.Items.Contains(file) == false)
                    {
                        listBox_mkvlist.Items.Add(file);

                        //Check whether the GUI needs an update
                        if (job.Done == false)
                        {
                            button_job.Text = "Stop the queue";
                            button_job.Enabled = true;
                        }
                    }
                }
            }
        }

        //Delete items from the mkv list
        private void listBox_mkvlist_MouseClick(object sender, MouseEventArgs e)
        {
            //Check if selectedItem exists
            if (listBox_mkvlist.SelectedItem != null)
            {
                String selitem = listBox_mkvlist.SelectedItem.ToString();
                listBox_mkvlist.Items.Remove(selitem);
            }
        }



        // ### LANGUAGE GROUP ###

        //Delete items from the language list
        private void listBox_languages_MouseClick(object sender, MouseEventArgs e)
        {
            //Check if selectedItem exists
            if (listBox_languages.SelectedItem != null)
            {
                String selitem = listBox_languages.SelectedItem.ToString();
                listBox_languages.Items.Remove(selitem);
            }
        }

        //Language add button event
        private void button_language_add_Click(object sender, EventArgs e)
        {
            language_add();
        }

        //Language add textbox enter event
        private void textBox_language_add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                language_add();
            }
        }

        //Add languages from the textbox directly into the language list
        private void language_add()
        {
            //Remove unwated spaces
            String newlang = textBox_language_add.Text.Replace(" ", "");
            if (textBox_language_add.Text != "")
            {
                //Check if language already exists
                if (listBox_languages.Items.Contains(newlang) == false)
                {
                    listBox_languages.Items.Add(newlang);
                    textBox_language_add.Text = "";
                }
            }
        }



        // ### JOB GROUP ###

        //Job start and stop button event
        private void button_job_Click(object sender, EventArgs e)
        {
            //Check if mkv list is empty
            if (listBox_mkvlist.Items.Count > 0)
            {
                //Check if MKVToolNix works
                if (job.CheckMkvToolNix(textBox_toolnix_path.Text) == true)
                {
                    //Check if a job should be started or stopped
                    if (timer_extract.Enabled == false)
                    {
                        //Check if a job and the button are in different states. This should not trigger.
                        if (job.Done == true)
                        {
                            //Set status to extraction mode
                            timer_extract.Start();
                        } else {
                            MessageBox.Show("Please wait for the last job to finish!", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else {
                        exitRequest = true;
                    }
                } else {
                    MessageBox.Show("MKVToolNix not found!", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please add MKV files first!", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        // ### MAIN ASYNC PROCESS INTERFACE ###

        private void timer_extract_Tick(object sender, EventArgs e)
        {
            //Check if the user pressed on the stop queue button
            if(exitRequest == true)
            {
                if (job.Done == false)
                {
                    //The final process is still running

                    //Update GUI elements
                    button_job.Text = "Stopping...";
                    button_job.Enabled = false;
                }
                else
                {
                    //The final process has finished

                    timer_extract.Stop();

                    //Reset exit request value for the next time
                    exitRequest = false;

                    //Update GUI elements
                    button_job.Text = "Extract";
                    button_job.Enabled = true;
                    groupBox_toolnix.Enabled = true;
                    groupBox_languages.Enabled = true;
                    toolStripStatusLabel_current.Text = "";

                    //Set the progress bar to max
                    toolStripProgressBar_current.Value = toolStripProgressBar_current.Maximum;

                    //Wait for user to press OK
                    MessageBox.Show("Extraction finished!", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                //The timer checks on each tick if the job is done and a new one/first one can be started.
                if (job.Done == true)
                {
                    //There are still entrys left in the mkv list
                    if (listBox_mkvlist.Items.Count > 0)
                    {

                        groupBox_toolnix.Enabled = false;
                        groupBox_languages.Enabled = false;

                        if (listBox_mkvlist.Items.Count > 1)
                        {
                            button_job.Text = "Stop the queue";
                            button_job.Enabled = true;
                        }
                        if (listBox_mkvlist.Items.Count == 1)
                        {
                            button_job.Text = "Waiting for the last job to finish...";
                            button_job.Enabled = false;
                        }

                        //Get the first item from the mkv list
                        string currentMkv = listBox_mkvlist.Items[0].ToString();
                        listBox_mkvlist.Items.Remove(currentMkv);
                        toolStripStatusLabel_current.Text = currentMkv;

                        //START THE JOB
                        job.Execute(textBox_toolnix_path.Text, currentMkv, listBox_languages.Items.Cast<string>().ToList());
                    }
                    //The mkv list is empty. The timer can be stopped. The gui can be resetted.
                    else
                    {
                        timer_extract.Stop();

                        //Update GUI elements
                        button_job.Text = "Extract";
                        button_job.Enabled = true;
                        groupBox_toolnix.Enabled = true;
                        groupBox_languages.Enabled = true;
                        toolStripStatusLabel_current.Text = "";

                        //Set the progress bar to max
                        toolStripProgressBar_current.Value = toolStripProgressBar_current.Maximum;

                        //Wait for user to press OK
                        MessageBox.Show("Extraction finished!", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            //Update progress bar
            toolStripProgressBar_current.Value = job.Progress;
        }
    }
}
