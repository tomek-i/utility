using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TIUtilities.Logic
{


    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;


        public SortableBindingList()
        {

        }

        public SortableBindingList(IList<T> list):base(list)
        {

        }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override ListSortDirection SortDirectionCore => _sortDirection;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;
        protected override void RemoveSortCore()
        {
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
            _isSorted = false;
        }
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _sortProperty = prop;
            _sortDirection = direction;
            var items = Items.ToList();
            items.Sort(Compare);
            _isSorted = true;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private int Compare(T left, T right)
        {
            var result = OnComparison(left, right);
            if (_sortDirection == ListSortDirection.Descending)
                result = -result;
            return result;
        }
        private int OnComparison(T left, T right)
        {
            object lValue = left == null ? null : _sortProperty.GetValue(left);
            object rValue = right == null ? null : _sortProperty.GetValue(right);

            if (lValue == null)
                return rValue == null ? 0 : -1;
            if (rValue == null) return 1;
            IComparable value = lValue as IComparable;
            if (value != null)
                return value.CompareTo(rValue);
            return lValue.Equals(rValue) ? 0 : String.Compare(lValue.ToString(), rValue.ToString(), StringComparison.Ordinal);
        }
    }
}