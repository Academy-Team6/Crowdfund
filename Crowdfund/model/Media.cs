using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class Media
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Paload { get; set; }
    }
    public class Photo : Media
    {
        public Photo()
        {
            Type = "photograph";
        }
    }
    public class Video : Media
    {
        public Video()
        {
            Type = "video";
        }
    }
}
