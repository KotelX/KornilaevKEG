using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KornilaevKEG.VM
{
    class ViewModel
    {
        public ObservableCollection<Core.Algorithms.IAlgirithm> algorithms { get; set; } = new ObservableCollection<Core.Algorithms.IAlgirithm>()
        {
            new Core.Algorithms.Сaesar(),
            new Core.Algorithms.Visener(),
            new Core.Algorithms.AES(),
            new Core.Algorithms.RSA()
        };
        public Core.Algorithms.IAlgirithm selectedAlgorithm { get; set; }
    }
}
