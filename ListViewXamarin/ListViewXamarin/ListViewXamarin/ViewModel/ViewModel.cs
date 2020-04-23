using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ListViewXamarin
{
    public class ViewModel
    {
        #region Fields

        private IEnumerable<BookInfo> bookInfo;

        #endregion

        #region Constructor

        public ViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public IEnumerable<BookInfo> BookInfo
        {
            get { return bookInfo; }
            set { this.bookInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            BookInfoRepository bookInfoRepository = new BookInfoRepository();
            bookInfo = bookInfoRepository.GetBookInfo();
        }
        #endregion
    }
}
