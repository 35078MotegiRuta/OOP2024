using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Calendar {
    public partial class MainPage : ContentPage {
        public List<DayModel> CalendarDays { get; set; }
        public string CurrentMonth { get; set; }
        public DayModel SelectedDay { get; set; }
        public string SelectedDayDetails { get; set; }

        private DateTime currentMonthDate;

        public MainPage() {
            InitializeComponent();
            currentMonthDate = DateTime.Now;
            CalendarDays = GenerateCalendar(currentMonthDate);
            CurrentMonth = currentMonthDate.ToString("yyyy年MM月");
            BindingContext = this;
        }

        // 月のカレンダーを生成
        public List<DayModel> GenerateCalendar(DateTime month) {
            var days = new List<DayModel>();

            // 月の最初の日と最終日を取得
            var firstDayOfMonth = new DateTime(month.Year, month.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // 月初から月末までの各日付を追加
            for (var date = firstDayOfMonth; date <= lastDayOfMonth; date = date.AddDays(1)) {
                days.Add(new DayModel {
                    Day = date.Day.ToString(),
                    Date = date
                });
            }

            return days;
        }

        // 前月ボタンがクリックされたとき
        private void OnPreviousMonthClicked(object sender, EventArgs e) {
            currentMonthDate = currentMonthDate.AddMonths(-1);
            CalendarDays = GenerateCalendar(currentMonthDate);
            CurrentMonth = currentMonthDate.ToString("yyyy年MM月");
            BindingContext = this;
        }

        // 次月ボタンがクリックされたとき
        private void OnNextMonthClicked(object sender, EventArgs e) {
            currentMonthDate = currentMonthDate.AddMonths(1);
            CalendarDays = GenerateCalendar(currentMonthDate);
            CurrentMonth = currentMonthDate.ToString("yyyy年MM月");
            BindingContext = this;
        }

        // スワイプ（左）で次月に切り替え
        private void OnSwipeLeft(object sender, SwipedEventArgs e) {
            currentMonthDate = currentMonthDate.AddMonths(1);
            CalendarDays = GenerateCalendar(currentMonthDate);
            CurrentMonth = currentMonthDate.ToString("yyyy年MM月");
            BindingContext = this;
        }

        // スワイプ（右）で前月に切り替え
        private void OnSwipeRight(object sender, SwipedEventArgs e) {
            currentMonthDate = currentMonthDate.AddMonths(-1);
            CalendarDays = GenerateCalendar(currentMonthDate);
            CurrentMonth = currentMonthDate.ToString("yyyy年MM月");
            BindingContext = this;
        }

        // 日付が選択されたとき
        private void OnDaySelected(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem is DayModel selectedDay) {
                SelectedDay = selectedDay;
                SelectedDayDetails = $"{selectedDay.Date.ToString("yyyy年MM月dd日")}が選択されました。";
                BindingContext = this;
            }
        }
    }

    // 日付を保持するモデル
    public class DayModel {
        public string Day { get; set; }
        public DateTime Date { get; set; }
    }
}
