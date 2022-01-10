
SequentialDigits(1000, 13000);

    IList<int> SequentialDigits(int low, int high) {
        var list = new List<int>();
        var digits = "123456789";
        
        for(var i = 0; i <= digits.Length-1; i++) {
            var j = 1;
            while(true) {            
                var str = digits.Substring(i, j);
                var num = Int32.Parse(str);
                
                if(num >= low && num <= high)
                    list.Add(num);
                
                j++;

                if(str.EndsWith('9')) {
                    j = 1;
                    break;
                } 
            }
        }
        
        var array = list.ToArray();
        Array.Sort(array);
        return array;
    }
