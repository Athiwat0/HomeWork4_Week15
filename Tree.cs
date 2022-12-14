class Tree<T> 
{
    private TreeNode<T> root = null;
    private int length = 0;

    public void AddSibling(int index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        TreeNode<T> ptr = this.GetTreeNode(index);
        node.SetNext(ptr.Next());
        ptr.SetNext(node);
        this.length++;
    }

    public void AddChild(int index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(index == -1)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetChild(ptr.Child());
            ptr.SetChild(node);
        }
        this.length++;
    }

    public int GetLength()
    {
        return this.length;
    }

    public T Get(int index)
    {
        TreeNode<T> ptr = this.GetTreeNode(index);
        return ptr.GetValue();
    }

    public TreeNode<T> GetTreeNode(int index)
    {
        int traverseStep = index;
        return this.Traverse(this.root, ref traverseStep);
    }

    private TreeNode<T> Traverse(TreeNode<T> currentTreeNode, ref int traverseStep)
    {
        TreeNode<T> ptr = currentTreeNode;
        T test = ptr.GetValue();
        if(traverseStep > 0 && currentTreeNode.Child() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Child(), ref traverseStep);
        }

        if(traverseStep > 0 && currentTreeNode.Next() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Next(), ref traverseStep);
        }

        return ptr;
    }
    private static Stack<T> stack_search = new Stack<T>();
    public void AddSiblingX(T search, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        TreeNode<T> ptr = this.GetTreeNodeX(search);
        node.SetNext(ptr.Next());
        node.SetParent(ptr.Parent());
        ptr.SetNext(node);

        this.length++;
    }

    public void AddChildX(T search, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(length == 0)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNodeX(search);
            node.SetChild(ptr.Child());
            node.SetParent(ptr);
            ptr.SetChild(node);
        }
        this.length++;
    }
    public T GetX(T search)
    {
        TreeNode<T> ptr = this.GetTreeNodeX(search);
        return ptr.GetValue();
    }

    public TreeNode<T> GetTreeNodeX(T search)
    { 
        T traverse = search;
        return this.TraverseX(this.root, search);
    }

    private TreeNode<T> TraverseX(TreeNode<T> currentTreeNode, T search)
    {
        TreeNode<T> ptr = currentTreeNode;
        T test = ptr.GetValue();

        if(test.Equals(search)){
            return ptr;
        }

        if( currentTreeNode.Child() != null)
        {
            ptr = this.TraverseX(currentTreeNode.Child(),  search);
        }

        if(currentTreeNode.Next() != null)
        {
            ptr = this.TraverseX(currentTreeNode.Next(),  search);
        }
        return ptr;
    }

    public Stack<T> GetStackpreson (int ser){
            TreeNode<T> node = GetTreeNode(ser);
            while(node.Parent() != null)
            {
                T Get = node.Parent().GetValue();
                stack_search.Push(Get);
                node = node.Parent();
            }
            return stack_search;
    }
}