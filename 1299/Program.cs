    int[] arr = {17,18,5,4,6,1};
    
    int[] a = new int[arr.Length];
    a[arr.Length-1] = -1;
    
    var max = arr[arr.Length-1];
    
    for(var i = arr.Length-2; i >= 0; i--) {
        if(arr[i+1] > max) {            
            arr[i] = arr[i+1];
            max = arr[i+1];
        }
        else
            arr[i] = max;
    }
    
    Console.WriteLine("");