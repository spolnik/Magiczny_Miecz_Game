using System.Windows;
using System.Windows.Controls;

namespace MagicznyMiecz.GUI.LayoutPanels
{
    public class BoardRing : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            if (this.Children.Count < 1) return new Size(0, 0);

            var firstChild = this.Children[0];
            firstChild.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            if (this.Children.Count < 2) return firstChild.DesiredSize;

            for (int i = 1; i < this.Children.Count; i++)
                this.Children[i].Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            return new Size(firstChild.DesiredSize.Width + 2 * this.Children[1].DesiredSize.Width,
                            firstChild.DesiredSize.Height + 2 * this.Children[1].DesiredSize.Height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (this.Children.Count < 2) return finalSize;

            var firstChild = this.Children[0];
            var firstChildOrigin = new Point(0, 0);
            var firstChildSize = new Size(finalSize.Width - 2*this.Children[1].DesiredSize.Width,
                                          finalSize.Height - 2*this.Children[1].DesiredSize.Height);
            //var firstChildSize = new Size(firstChild.DesiredSize.Width, firstChild.DesiredSize.Height);

            int right;
            int bottom;
            int left;
            var top = right = bottom = left = (this.Children.Count - 1) / 4;

            switch ((this.Children.Count - 1) % 4)
            {
                case 1:
                    top++;
                    break;
                case 2:
                    top++;
                    bottom++;
                    break;
                case 3:
                    top++;
                    left++;
                    right++;
                    break;
            }

            if (this.Children.Count < 2) return finalSize;

            var childSize = new Size(this.Children[1].DesiredSize.Width, this.Children[1].DesiredSize.Height);

            var stepWidth = (finalSize.Width - 2 * childSize.Width) / bottom;
            var stepHeight = finalSize.Height / left;

            var childOrigin = new Point(0, (stepHeight - childSize.Height) / 2);

            firstChildOrigin.X = (finalSize.Width - firstChildSize.Width) / 2;
            firstChildOrigin.Y = (finalSize.Height - firstChildSize.Height) / 2;

            firstChild.Arrange(new Rect(firstChildOrigin, firstChildSize));

            var rightEnded = false;
            var bottomEnded = false;
            var leftEnded = false;

            for (int i = 1; i < this.Children.Count; i++)
            {
                var child = this.Children[i];

                if (left > 0)
                {
                    child.Arrange(new Rect(childOrigin, childSize));
                    childOrigin.Y += stepHeight;
                    left--;
                    continue;
                }
                if (!leftEnded)
                {
                    childOrigin.Y = finalSize.Height - childSize.Height;
                    childOrigin.X = (stepWidth + childSize.Width) / 2;
                    leftEnded = true;
                }
                if (bottom > 0)
                {
                    child.Arrange(new Rect(childOrigin, childSize));
                    childOrigin.X += stepWidth;
                    bottom--;
                    continue;
                }
                if (!bottomEnded)
                {
                    childOrigin.X = finalSize.Width - childSize.Width;
                    childOrigin.Y = finalSize.Height - (stepHeight + childSize.Height) / 2;
                    bottomEnded = true;
                }
                if (right > 0)
                {
                    child.Arrange(new Rect(childOrigin, childSize));
                    childOrigin.Y -= stepHeight;
                    right--;
                    continue;
                }
                if (!rightEnded)
                {
                    stepWidth = (finalSize.Width - 2 * childSize.Width) / top;
                    childOrigin.Y = 0;
                    childOrigin.X = finalSize.Width - (stepWidth + 3 * childSize.Width) / 2;
                    rightEnded = true;
                }
                if (top > 0)
                {
                    child.Arrange(new Rect(childOrigin, childSize));
                    childOrigin.X -= stepWidth;
                    top--;
                    continue;
                }

            }

            return finalSize;
        }
    }
}
