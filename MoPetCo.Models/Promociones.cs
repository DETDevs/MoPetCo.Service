using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Models
{
    public class Promociones
    {
        public int PromotionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public string ShadowColorClass { get; set; } = string.Empty;

        public string BgColorClass { get; set; } = string.Empty;

        public string TextColor { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public bool ShowOnHomePage { get; set; }

        public bool ShowOnPromotionsPage { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
