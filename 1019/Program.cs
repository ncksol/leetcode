var head = new ListNode();

var list = new List<int>();
while(head != null)
{    
    var nextNode = head.next;
    while(nextNode != null && nextNode.val <= head.val)
    {        
        nextNode = nextNode.next;
    }

    if(nextNode != null)
    {
        list.Add(nextNode.val);
    }
    else
    {
        list.Add(0);
    }

    head = head.next;
}

return list.ToArray();



public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}