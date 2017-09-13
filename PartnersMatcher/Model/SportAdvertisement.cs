using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    class SportAdvertisement : Advertisement
    {
        private string type;
        private string level;


        public SportAdvertisement(int watched,string type, string level, string owner, string location, DateTime datepublished, string description) : base(watched, owner, location, datepublished, description)
        {
            this.type = type;
            this.level = level;
        }

        #region properties
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }
        #endregion

    }
}
