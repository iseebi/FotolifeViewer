using System.Collections.Generic;

namespace FotolifeViewer.Core.Models
{
    public class HatenaFotolifeItem
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Date { get; set; }

        public string ImageUrl { get; set; }

        public string ImageUrlSmall { get; set; }

        public string ImageUrlMedium { get; set; }

        public string Syntax { get; set; }

        public IEnumerable<string> Colors { get; set; }
    }
}

