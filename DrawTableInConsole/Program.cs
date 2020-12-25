using System;
using System.Text;

namespace DrawTableInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTable("id", "date", "title", "content", 0);
            CreateTable("id", "date", "title", "content", 1);
            CreateTable("id", "date", "title", "content", 1);
            CreateTable("id", "date", "title", "content", 1);
            CreateTable("id", "date", "title", "content", 1);
            CreateTable("id", "date", "title", "content", 2);
            Console.ReadLine();

        }

        static void CreateTable(string id, string date, string title, string content, int Vitri)
        {
            //Vitri 0: top table và chứa luôn tiêu đề rồi đóng lại luôn
            //1: middle table chứa dữ liệu ở giữa (chưa phải cuối cùng) và chốt bảng ở giữa,
            //2: bottom table chứa dữ liệu cuối cùng và chốt bảng
            const string TopLeftJoint = "┌";
            const string TopRightJoint = "┐";
            const string BottomLeftJoint = "└";
            const string BottomRightJoint = "┘";
            const string TopJoint = "┬";
            const string BottomJoint = "┴";
            const string LeftJoint = "├";
            const string MiddleJoint = "┼";
            const string RightJoint = "┤";
            const char HorizontalLine = '─';
            const string VerticalLine = "│";

            StringBuilder tableSb = new StringBuilder();
            if (Vitri == 0)
            {
                //Top
                tableSb.Append(TopLeftJoint)
                    .Append(HorizontalLine, 3).Append(TopJoint)
                    .Append(HorizontalLine, 19).Append(TopJoint)
                    .Append(HorizontalLine, 20).Append(TopJoint)
                    .Append(HorizontalLine, 30)
                    .Append(TopRightJoint).AppendLine();
                //Chứa Tiêu đề
                tableSb.Append(VerticalLine)
                    .Append("id ").Append(VerticalLine)
                    .Append("date               ").Append(VerticalLine)
                    .Append("title               ").Append(VerticalLine)
                    .Append("content                       ").Append(VerticalLine)
                    .AppendLine();
                //bottom chốt ở giữa
                tableSb.Append(LeftJoint)
                    .Append(HorizontalLine, 3).Append(MiddleJoint)
                    .Append(HorizontalLine, 19).Append(MiddleJoint)
                    .Append(HorizontalLine, 20).Append(MiddleJoint)
                    .Append(HorizontalLine, 30)
                    .Append(RightJoint);
                Console.WriteLine(tableSb);

            }
            else if (Vitri == 1)
            {
                //Chứa dữ liệu
                tableSb.Append(VerticalLine)
                    .Append("id ").Append(VerticalLine)
                    .Append("date               ").Append(VerticalLine)
                    .Append("title               ").Append(VerticalLine)
                    .Append("content                       ").Append(VerticalLine)
                    .AppendLine();
                //bottom chốt ở giữa
                tableSb.Append(LeftJoint)
                    .Append(HorizontalLine, 3).Append(MiddleJoint)
                    .Append(HorizontalLine, 19).Append(MiddleJoint)
                    .Append(HorizontalLine, 20).Append(MiddleJoint)
                    .Append(HorizontalLine, 30)
                    .Append(RightJoint);
                
                Console.WriteLine(tableSb);
            }
            else if (Vitri == 2)
            {
                //Chứa dữ liệu
                tableSb.Append(VerticalLine)
                    .Append("id ").Append(VerticalLine)
                    .Append("date               ").Append(VerticalLine)
                    .Append("title               ").Append(VerticalLine)
                    .Append("content                       ").Append(VerticalLine)
                    .AppendLine();
                //bottom cuoi cung the last bottom
                tableSb.Append(BottomLeftJoint)
                    .Append(HorizontalLine, 3).Append(BottomJoint)
                    .Append(HorizontalLine, 19).Append(BottomJoint)
                    .Append(HorizontalLine, 20).Append(BottomJoint)
                    .Append(HorizontalLine, 30)
                    .Append(BottomRightJoint).AppendLine();
                //tableSb.Append(BottomLeftJoint).Append(HorizontalLine, 10).Append(BottomRightJoint).AppendLine();
                Console.WriteLine(tableSb);
            }





        }
    }
}
