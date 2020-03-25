using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Home_Planning_Studio.Utils
{
    public static class Vector
    {
        public static double GetVectorLength(PointF startPoint, PointF endPoint)
        {
            return Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) 
                            + Math.Pow(endPoint.Y - startPoint.Y, 2));
        }

        public static PointF GetReplacedSubVectorEndPoint(PointF startPoint, PointF endPoint, PointF offsetPoint, float expectedLength)
        {
            var vectorX = endPoint.X - startPoint.X;
            var vectorY = endPoint.Y - startPoint.Y;
            var vectorLength = (float)Math.Sqrt(vectorX * vectorX + vectorY * vectorY);
            var dirVectorX = vectorX / vectorLength;
            var dirVectorY = vectorY / vectorLength;
            dirVectorX *= expectedLength;
            dirVectorY *= expectedLength;
            return new PointF(dirVectorX + offsetPoint.X, dirVectorY + offsetPoint.Y);
        }

        public static PointF GetRotatedPoint(float angle, PointF fromPoint, PointF toPoint)
        {
            var m = new Matrix();
            m.RotateAt(angle, fromPoint);
            var arr = new PointF[] { toPoint };
            m.TransformPoints(arr);
            toPoint = arr[0];
            return toPoint;
        }     
    }
}
