using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataGridDELETE
{
    public enum Operation
    {
        [Description("Купить")]
        Buy,
        Sell
    }
    public class MainVM : ViewModelBase
    {
        public static MainVM Instance { get; set; }
        #region Коллекция
        private ObservableCollection<Data> _dataCollection;
        private Data _selectedData;
        public ObservableCollection<Data> DataCollection
        {
            get => _dataCollection;
            set => SetField(ref _dataCollection, value);
        }
        #endregion

        #region SelectedItem

        public Data SelectedData
        {
            get => _selectedData;
            set => SetField(ref _selectedData, value);
        }

        #endregion

        public MainVM()
        {
            Instance = this;
            DataCollection = new ObservableCollection<Data>();
            for (int i = 0; i < 100; i++)
            {
                var temp = new Data()
                    { Name = $"{i} - блабла", Description = $"{i} - Что то там", SelectedComboBox = "Один" };
                DataCollection.Add(temp);
            }

        }
    }

    public class Data : ViewModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private string _selectedComboBox;
        private Operation _selectedOperation;
       
        private Operation _selectedOperationApDg;

        public string SelectedComboBox
        {
            get => _selectedComboBox;
            set => SetField(ref _selectedComboBox, value);
        }

        public Operation SelectedOperation
        {
            get => _selectedOperation;
            set => SetField(ref _selectedOperation, value);
        }
        private Operation _selectedOperationAp;
        public Operation SelectedOperationAp 
        {
            get => _selectedOperationAp;
            set => SetField(ref _selectedOperationAp, value);
        }

        public Operation SelectedOperationApDg
        {
            get => _selectedOperationApDg;
            set => SetField(ref _selectedOperationApDg, value);
        }
    }

    public class ViewModelBase : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
