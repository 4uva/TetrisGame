using System;
using System.Collections.Generic;
using System.ComponentModel;//[CallerMemberName] позволяет уведомлять связанный элемент 
                            // управления об  изменении свойства, чтобы элемент управления 
                            // мог отображать обновленные сведения.
using System.Runtime.CompilerServices;
using System.Text;

namespace Tetris
{
    public class BaseViewModel : INotifyPropertyChanged//реализация интерфейса - цель - отображать обновленные сведения.для обновления све
    {
        bool isBusy = false;//поле класса
        public bool IsBusy // свойство
        {
            get { return isBusy; }//  get должна возвращать свойство
            set { SetProperty(ref isBusy, value); } // то, что геттер вернул, и есть значение
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)// non comprehensional semantic for 20-22 lines
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))//сравнение или величины равны
                return false;

            backingStore = value;//присвоение значения аргументу
            onChanged?.Invoke();//проверка объекта на null так как тип Action возвращает null
            OnPropertyChanged(propertyName);//сравнение
            return true;//сравнение
        }

        #region INotifyPropertyChanged //сравнение
        //Делегат Представляет метод, который обрабатывает
        // событие PropertyChanged, возникающее 
        //при изменении свойства компонента.
        public event PropertyChangedEventHandler PropertyChanged;//мне непонятна семантика события
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}


