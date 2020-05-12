using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKS_Extractor_GUI
{
    public class MKVJson
    {
        private List<String> errors;
        private List<Track> tracks;

        public List<string> Errors { get => errors; set => errors = value; }
        public List<Track> Tracks { get => tracks; set => tracks = value; }

        public class Track
        {
            string codec;
            int id;
            string type;


            public string Codec { get => codec; set => codec = value; }
            public int Id { get => id; set => id = value; }
            public string Type { get => type; set => type = value; }

            public prop Properties { get; set; }

            public class prop
            {
                String codec_id;
                Boolean forced_track;
                String language;

                public string Codec_id { get => codec_id; set => codec_id = value; }
                public bool Forced_track { get => forced_track; set => forced_track = value; }
                public string Language { get => language; set => language = value; }
            }
        }
    }
}
