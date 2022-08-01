// #Week5_1 : 타겟 넘버

public class Week5_1
{
    int iAnswer = 0;

    public class BinaryTreeNode
    {
        public int iData { get; set; }
        public BinaryTreeNode LeftNode { get; set; } // Minus
        public BinaryTreeNode RightNode { get; set; } // Plus

        public BinaryTreeNode(int iDataInput)
        {
            this.iData = iDataInput;
        }
    }

    public class BinaryTree
    {
        public BinaryTreeNode Root { get; set; }
    }

    public BinaryTreeNode FindLeafNode(BinaryTreeNode Root, int iInputData)
    {
        if (Root == null)
            return null;

        if (Root.LeftNode != null)
            Root.LeftNode = FindLeafNode(Root.LeftNode, iInputData);

        if (Root.RightNode != null)
            Root.RightNode = FindLeafNode(Root.RightNode, iInputData);

        if (Root.LeftNode == null && Root.RightNode == null)
        {
            Root.LeftNode = new BinaryTreeNode(Root.iData - iInputData);
            Root.RightNode = new BinaryTreeNode(Root.iData + iInputData);
        }

        return Root;
    }

    public BinaryTreeNode FindTarget(BinaryTreeNode Root, int iTarget)
    {
        if (Root == null)
            return null;

        if (Root.LeftNode != null && Root.RightNode != null)
        {
            if (Root.LeftNode.iData != iTarget)
                FindTarget(Root.LeftNode, iTarget);

            if (Root.RightNode.iData != iTarget)
                FindTarget(Root.RightNode, iTarget);

            if (Root.LeftNode.iData == iTarget)
            {
                if (Root.LeftNode.LeftNode == null && Root.LeftNode.RightNode == null)
                    iAnswer++;
                else
                    FindTarget(Root.LeftNode, iTarget);
            }

            if (Root.RightNode.iData == iTarget)
            {
                if (Root.LeftNode.LeftNode == null && Root.LeftNode.RightNode == null)
                    iAnswer++;
                else
                    FindTarget(Root.RightNode, iTarget);
            }

            return null;
        }
        else
            return null;
    }

    public int solution(int[] numbers, int target)
    {
        BinaryTree StartPlusTree = new BinaryTree();
        BinaryTree StartMinusTree = new BinaryTree();

        for (int iDepth = 0; iDepth < numbers.Length; iDepth++)
        {
            if (iDepth == 0)
            {
                StartPlusTree.Root = new BinaryTreeNode(numbers[iDepth]);
                StartMinusTree.Root = new BinaryTreeNode(-numbers[iDepth]);
            }
            else
            {
                StartPlusTree.Root = FindLeafNode(StartPlusTree.Root, numbers[iDepth]);
                StartMinusTree.Root = FindLeafNode(StartMinusTree.Root, numbers[iDepth]);
            }
        }

        FindTarget(StartPlusTree.Root, target);
        FindTarget(StartMinusTree.Root, target);

        return iAnswer;
    }
}