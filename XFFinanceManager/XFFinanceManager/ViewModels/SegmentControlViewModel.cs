using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFinanceManager.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SegmentControlViewModel
    {
        public SegmentControlViewModel()
        {
            SelectedSegment = -1;
        }

        public int SelectedSegment { get; set; }
    }
}
