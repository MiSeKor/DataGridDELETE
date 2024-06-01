using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataGridDELETE
{
    public static class EnumToItemSourse
    {
        public static readonly DependencyProperty EnumTypeProperty =
            DependencyProperty.RegisterAttached("EnumType", typeof(Type), typeof(EnumToItemSourse),
                new PropertyMetadata(null, OnEnumTypeChanged));

        public static Type GetEnumType(DependencyObject obj) => (Type)obj.GetValue(EnumTypeProperty);

        public static void SetEnumType(DependencyObject obj, Type value) => obj.SetValue(EnumTypeProperty, value);

        /// <summary>
        /// Реализовано для ItemsControl и DataGridComboBoxColumn
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnEnumTypeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Dictionary<Enum, string>? temp = null;
            if (e.NewValue is Type enumType)
            {
                temp = Enum.GetValues(enumType).Cast<Enum>().ToDictionary(
                    x => x,
                    x => x.GetType().GetField(x.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .Cast<DescriptionAttribute>()
                        .FirstOrDefault()?.Description ?? x.ToString()
                );
            }
            if (obj is ItemsControl itemsControl && temp != null)
                itemsControl.ItemsSource = temp;

            if (obj is DataGridComboBoxColumn dataGridComboBoxColumn && temp != null)
                dataGridComboBoxColumn.ItemsSource = temp;
        }
    }
}
