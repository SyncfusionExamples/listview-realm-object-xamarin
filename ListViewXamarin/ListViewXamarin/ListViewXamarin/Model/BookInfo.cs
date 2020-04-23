using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class BookInfo : Realms.RealmObject
    {
        #region Constructor

        public BookInfo()
        {

        }
        #endregion

        #region Properties

        public string BookName { get; set; }

        public string BookDescription { get; set; }

        public string BookAuthor { get; set; }
        #endregion
    }
}
