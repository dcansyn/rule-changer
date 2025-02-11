namespace RuleChanger.UI.Events;

public static class ListViewEvents
{
    public static void MouseDoubleClickRemove(this ListView listView)
    {
        var focusedItem = listView.FocusedItem;
        if (focusedItem != null && MessageBox.Show("Are you sure to delete?", "Delete | Rule Changer", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
            focusedItem.Remove();
    }
}
