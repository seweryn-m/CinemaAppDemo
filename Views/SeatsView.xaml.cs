﻿using System;
using System.Collections.Generic;
using System.Linq;
using CinemaAppDemo.Models;
using SkiaSharp;
using Xamarin.Forms;

namespace CinemaAppDemo.Views
{
    public partial class SeatsView : ContentPage
    {
        Dictionary<int, int> data = new Dictionary<int, int>();
        SKPaint availablePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColor.Parse("#343352")
        };

        SKPaint reservedPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColor.Parse("#343352")
        };

        SKPaint yourSeatPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColor.Parse("#9747FF")
        };

        SKPaint textPaint = new SKPaint
        {
            TextSize = 40,
            Color = SKColor.Parse("#343352")
        };

        public Ticket SelectedTicket { get; set; }

        public SeatsView(Ticket ticket)
        {
            InitializeComponent();
            SelectedTicket = ticket;
            Init();
            BindingContext = this;
        }

        private void Init()
        {
            var rand = new Random();
            for(int i = 0; i < 120; i++)
            {
                data.Add(i, rand.Next(0, 2));
            }
        }

        private void canvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var x = 60;
            var y = 60;
            var row = -1;
            var columns = 14;
            var itemHeight = 40;
            var itemWidth = 40;
            var margin = 20;
            var cornerRadius = 4;
            var items = 0;

            for(int i = 0; i < data.Count; i++)
            {
                if(items == 0)
                {
                    row += 1;
                    items = GetColumn(row);
                    var count = (columns - items) / 2;
                    var offset = (count * itemWidth) + (count * margin);
                    x = 60 + offset;
                    y = (itemWidth + ((itemWidth + margin) * row));
                }
                else
                {
                    x += itemWidth + margin;
                }

                var seatColorIndex = data[i];
                if (SelectedTicket.Seats.Any(s => s == i))
                    seatColorIndex = 2;

                canvas.DrawRoundRect(new SKRoundRect(new SKRect(x, y, x + itemHeight, y + itemWidth), cornerRadius),
                    GetColor(seatColorIndex));

                items -= 1;
                if(items == 0)
                {
                    canvas.DrawText($"{row + 1}", 0, y + margin + (itemHeight / 2), textPaint);
                }
            }
        }

        private SKPaint GetColor(int seatColorIndex)
        {
            switch (seatColorIndex)
            {
                case 0:
                default:
                    return availablePaint;
                case 1:
                    return reservedPaint;
                case 2:
                    return yourSeatPaint;
            }
        }

        private int GetColumn(int row)
        {
            switch (row)
            {
                case 0:
                    return 8;
                case 1:
                case 9:
                    return 10;
                case 2:
                case 3:
                case 8:
                    return 12;
                default:
                    return 14;
            }
        }
    }
}
