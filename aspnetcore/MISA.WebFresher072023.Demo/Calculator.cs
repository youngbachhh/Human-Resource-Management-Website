namespace MISA.WebFresher072023.Api
{

    public class Calculator
    {
        /// <summary>
        /// Tổng 2 số nguyên
        /// </summary>
        /// <param name="a">int</param>
        /// <param name="b">int</param>
        /// <returns>
        /// Tổng 2 số nguyên
        /// </returns>
        /// CreatedBy: youngbachhh (12/09/2023)
        public int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// Tổng các số nguyên
        /// </summary>
        /// Một chuỗi các số nguyên phân tách với nhau bởi dấu phẩy
        /// <param name="operands">string</param>
        /// <returns>
        /// Chuỗi rỗng - Trả về 0
        /// Chuỗi chứa giá trị âm - Throw ra ngoại lệ FormatException
        /// Chuỗi hợp lệ - Trả về tổng các số nguyên
        /// </returns>
        /// CreatedBy: youngbachhh (12/09/2023)
        public int Add(string operands)
        {
            // Nếu chuỗi rỗng thì trả về 0
            if (string.IsNullOrEmpty(operands))
            {
                return 0;
            }

            // Cắt chuỗi thành mảng các chuỗi toán hạng
            string[] numbers = operands.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            bool valid = true;
            var sum = 0;
            var message = "Không chấp nhận toán hạng âm: ";

            // Kiểm tra từng chuỗi toán hạng
            foreach (var number in numbers)
            {
                int value;

                try
                {
                    value = int.Parse(number);
                }
                catch (FormatException)
                {
                    throw new FormatException("Input không đúng định dạng");
                }

                if (value < 0)
                {
                    message += number.ToString();
                    message += ", ";
                    valid = false;
                }
                else
                {
                    sum += value;
                }
            }

            // Nếu có chuỗi toán hạng chứa giá trị âm thì ném ra ngoại lệ với thông báo
            if (!valid)
            {
                message = message.TrimEnd(' ', ',');
                throw new FormatException(message);
            }

            return sum;
        }

        /// <summary>
        /// Hiệu 2 số nguyên
        /// </summary>
        /// <param name="a">int</param>
        /// <param name="b">int</param> 
        /// <returns>
        /// Hiệu 2 số nguyên
        /// </returns>
        /// CreatedBy: youngbachhh (12/09/2023)
        public int Sub(int x, int y)
        {
            return x - y;
        }


        /// <summary>
        /// Tích 2 số nguyên
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        /// <returns>
        /// Tích 2 số nguyên
        /// </returns>
        /// CreatedBy: youngbachhh (12/09/2023)
        public int Mul(int x, int y)
        {
            return x * y;
        }

        /// <summary>
        /// Thương 2 số nguyên
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="b">int</param>
        /// <returns>
        /// Thương 2 số nguyên
        /// </returns>
        /// CreatedBy: youngbachhh (12/09/2023)
        public int Div(int a, int b)
        {
            var message = "Không thể chia cho 0";

            if(b == 0)
            {
                throw new Exception(message);
            }

            return a / b;
        }
    }
}
