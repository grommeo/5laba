using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5laba.Objects;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _5laba.Objects
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public Action<Circle> OnCircleOverlap;
        public Action<EvilCircle> OnEvilCircleOverlap;
        public float vX, vY;
        Image image = Image.FromFile("C:\\Users\\пк\\Desktop\\star.jpg");

        public Player(float x, float y, float angle) : base(x, y, angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(
                //new SolidBrush(Color.DeepSkyBlue),
                new SolidBrush(Color.Black),
                -15, -15,
                30, 30
                );
            g.DrawEllipse(
                new Pen(Color.White, 2),
                -15, -15,
                30, 30
                );
            //g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
            g.DrawImage(
                image,
                -15, -15,
                30, 30
                );
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            if(obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
            if(obj is Circle)
            {
                OnCircleOverlap(obj as Circle);
            }
            if (obj is EvilCircle)
            {
                OnEvilCircleOverlap(obj as EvilCircle);
            }
        }
    }
}
