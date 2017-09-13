using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    public abstract class Advertisement
    {
        private string owner;
        private string location;
        private DateTime datepublished;
        private string description;
        int watched;
        #region properties
        public string Owner
        {
            get
            {
                return owner;
            }

            set
            {
                owner = value;
            }
        
        }

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }
        public DateTime Datepublished
        {
            get
            {
                return datepublished;
            }

            set
            {
                datepublished = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int Watched
        {
            get
            {
                return watched;
            }

            set
            {
                watched = value;
            }
        }
        #endregion
        public Advertisement(int watched,string owner, string location, DateTime datepublished, string description)
        {
            this.owner= owner;
            this.location = location;
            this.datepublished = datepublished;
            this.description = description;
            this.watched = watched;
        }
    }
}
