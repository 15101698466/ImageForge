using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageForge.CustomControl
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ImageForge.Control"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ImageForge.Control;assembly=ImageForge.Control"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:CircularProgressBar/>
    ///
    /// </summary>
    public class CircularProgressBar : Control
    {
		// 模板中的路径元素名称
		private Path _arcPath;

		static CircularProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CircularProgressBar), new FrameworkPropertyMetadata(typeof(CircularProgressBar)));
        }
		 


		public double TextValue
		{
			get { return (double)GetValue(TextValueProperty); }
			set { SetValue(TextValueProperty, value); }
		}

		// Using a DependencyProperty as the backing store for TextValue.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TextValueProperty =
			DependencyProperty.Register("TextValue", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(70d));



		public double StrokeThickness
		{
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(10d));





        public Brush Stroke
		{
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(CircularProgressBar), new PropertyMetadata(Brushes.DodgerBlue));





        public Brush BackgroundStroke
		{
            get { return (Brush)GetValue(BackgroundStrokeProperty); }
            set { SetValue(BackgroundStrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundStroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundStrokeProperty =
            DependencyProperty.Register("BackgroundStroke", typeof(Brush), typeof(CircularProgressBar), new PropertyMetadata(Brushes.LightGray));




        public bool ShowPercentage
		{
            get { return (bool)GetValue(ShowPercentageProperty); }
            set { SetValue(ShowPercentageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowPercentage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowPercentageProperty =
            DependencyProperty.Register("ShowPercentage", typeof(bool), typeof(CircularProgressBar), new PropertyMetadata(true));

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			_arcPath = GetTemplateChild("PART_Arc") as Path;
			if (_arcPath != null)
			{
				// 订阅控件大小变化事件（或通过布局更新）
				this.SizeChanged += (s, e) => UpdateArc();
				UpdateArc();
			}
		}


		private void UpdateArc()
		{
			if (_arcPath == null) return;

			double width = this.ActualWidth;
			double height = this.ActualHeight;
			if (width <= 0 || height <= 0) return;

			double thickness = this.StrokeThickness;
			double radius = (Math.Min(width, height) - thickness) / 2.0;
			if (radius <= 0) return;

			Point center = new Point(width / 2.0, height / 2.0);

			// 计算当前角度（以弧度为单位），起始角度 -90°
			double percent = (this.TextValue - 0) / (100 - 0);
			double angle = -90 + percent * 360; // 角度值
			double rad = angle * Math.PI / 180.0;

			// 起点（起始角度 -90°，即正上方）
			Point startPoint = new Point(center.X, center.Y - radius);

			// 终点（根据当前角度）
			Point endPoint = new Point(
				center.X + radius * Math.Cos(rad),
				center.Y + radius * Math.Sin(rad)
			);

			// 判断是否为大弧（角度差超过 180°）
			bool isLargeArc = Math.Abs(percent * 360) > 180;

			// 构建路径数据
			PathFigure figure = new PathFigure
			{
				StartPoint = startPoint,
				IsClosed = false
			};

			ArcSegment arc = new ArcSegment
			{
				Point = endPoint,
				Size = new Size(radius, radius),
				IsLargeArc = isLargeArc,
				SweepDirection = SweepDirection.Clockwise
			};
			figure.Segments.Add(arc);

			PathGeometry geometry = new PathGeometry();
			geometry.Figures.Add(figure);

			// 应用路径数据，同时设置颜色和粗细
			_arcPath.Data = geometry;
			_arcPath.Stroke = this.Stroke;
			_arcPath.StrokeThickness = thickness;
			_arcPath.StrokeLineJoin = PenLineJoin.Round;
		}


	}
}
