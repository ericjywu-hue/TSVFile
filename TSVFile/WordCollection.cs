using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TSVFile
{
    public class WordCollection : Collection<WordItem>
    {
        /// <summary>
        /// 從字串陣列載入資料
        /// </summary>
        /// <param name="lines">輸入的單字字串陣列</param>
        public void LoadFromStringArray(string[] lines)
        {
            // 將字串陣列的資料載入到 WordCollection 物件中
            foreach (string line in lines)
            {
                // 產生 WordItem 物件
                WordItem item = new WordItem(line);
                this.Add(item);
            }
        }

    }
}
