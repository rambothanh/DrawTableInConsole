using System;
using System.Text;

namespace DrawTableInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTable("id", "date", "title", "content", 0);
            CreateTableMutiLine("id", "date ",
                "title title title title title title title title title title title title title title title title title " +
                "title title ","content content content content content content content content content content content " +
                "content content content content content content content content content content content content content ", false);

            CreateTable("id", "date", "title", "content", 1);
            CreateTable("id", "date", "title", "content", 1);
            CreateTableMutiLine("id", "date ",
                "title title title title title title title title title title title title title title title title title " +
                "title title ", "content content content content content content content content content content content " +
                "content content content content content content content content content content content content content ", true);
            Console.ReadLine();

        }

        //Tạo bảng với title và content dài có nhiều dòng, bắt đầu từ dữ liệu, không có tiêu đề
        static void CreateTableMutiLine(string id, string date, string title, string content, Boolean bottomTable)
        {
            
                var lenTitle = title.Length;
                var lineTitle = lenTitle / 20;
                var lenContent = content.Length;
                var lineContent = lenContent / 30;
                var maxLine = Math.Max(lineTitle, lineContent);
                for (int i = 0; i <= maxLine; i++)
                {
                    //Vị trí bằng 3 là chưa chốt dòng
                    //vị trí bằng 1 là chốt dòng luôn để sang dòng mới
                    //vị trí bằng 2 là chốt bảng luôn
                    int viTri = 3;
                    

                    if (i == maxLine && bottomTable)
                    {
                        viTri = 2;
                    }else if(i == maxLine)
                    {
                        viTri = 1;
                    }

                    if (i == 0)
                    {
                        //Hiện dòng đầu tiên
                        CreateTable(id, date, title.Substring(0, Math.Min(lenTitle, 20)), content.Substring(0, Math.Min(lenContent, 30)), viTri);
                        
                    }
                    else
                    {
                        if (i <= Math.Min(lineTitle, lineContent))
                        {
                            CreateTable("", "", title.Substring(20 * i, Math.Min(lenTitle - 20 * i, 20)), content.Substring(30 * i, Math.Min(lenContent - 30 * i, 30)), viTri);
                           

                        }
                        else if (lineTitle >= lineContent)
                        {
                            CreateTable("", "", title.Substring(20 * i, Math.Min(lenTitle - 20 * i, 20)),"", viTri);
                            
                        }
                        else if (lineTitle < lineContent)
                        {
                            CreateTable("", "", "", content.Substring(30 * i, Math.Min(lenContent - 30 * i, 30)), viTri);
                            
                        }

                    }
                }
        }

        static void CreateTable(string id, string date, string title, string content, int Vitri)
        {
            //Vitri 0: top table và chứa luôn tiêu đề rồi đóng lại luôn
            //1: middle table chứa dữ liệu ở giữa (chưa phải cuối cùng) và chốt bảng ở giữa,
            //2: bottom table chứa dữ liệu cuối cùng và chốt bảng
            //3: middle table chứa dữ liệu ở giữa (không chốt bảng giưa)
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
            //Them khoan trắng
            id = AddSpace(id, 3);
            date = AddSpace(date, 19);
            title = AddSpace(title, 20);
            content = AddSpace(content, 30);
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
                    .Append(id).Append(VerticalLine)
                    .Append(date).Append(VerticalLine)
                    .Append(title).Append(VerticalLine)
                    .Append(content).Append(VerticalLine)
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
                    .Append(id).Append(VerticalLine)
                    .Append(date).Append(VerticalLine)
                    .Append(title).Append(VerticalLine)
                    .Append(content).Append(VerticalLine)
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
                    .Append(id).Append(VerticalLine)
                    .Append(date).Append(VerticalLine)
                    .Append(title).Append(VerticalLine)
                    .Append(content).Append(VerticalLine)
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
            else if (Vitri == 3)
            {
                //Chứa dữ liệu
                tableSb.Append(VerticalLine)
                    .Append(id).Append(VerticalLine)
                    .Append(date).Append(VerticalLine)
                    .Append(title).Append(VerticalLine)
                    .Append(content).Append(VerticalLine);


                Console.WriteLine(tableSb);
            }
        }
        //thêm khoản trẳng cho vừa độ rộng
        static string AddSpace(string str,int doRong)
        {
            var strLen = str.Length;
            while ((doRong- strLen) >0)
            {
                str = str + " ";
                doRong--;
            }

            return str;
        }
    }
}
