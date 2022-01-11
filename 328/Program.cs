var head = new ListNode(5);
var prev = new ListNode(4);
prev.next = head;
head = prev;
prev = new ListNode(3);
prev.next = head;
head = prev;
prev = new ListNode(2);
prev.next = head;
head = prev;
prev = new ListNode(1);
prev.next = head;
head = prev;




ListNode OddEvenList(ListNode head)
{
    var even = new List<ListNode>();
    var odd = new List<ListNode>();

    var k = 0;
    while(head != null)
    {
        if(k % 2 == 0)
        {
            odd.Add(head);
        }
        else
        {
            even.Add(head);
        }

        head = head.next;
        k++;
    }

    for (int i = 0; i < even.Count-1; i++)
    {
        even[i].next = even[i+1];
    }
    even[even.Count-1].next = null;

    for (int i = 0; i < odd.Count - 1; i++)
    {
        odd[i].next = odd[i + 1];
    }
    odd[odd.Count - 1].next = even[0];
    return odd[0];
}

OddEvenList(head);


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