using System;

class Branch
{
    public List<Branch> branches = new List<Branch>();
}

class Program
{
    static void Main(string[] args)
    {
        // Creating hierarchical structure with parent and child branches
        Branch tree = new Branch();
        Branch branch1 = new Branch();
        Branch branch2 = new Branch();
        Branch branch3 = new Branch();
        Branch branch4 = new Branch();
        Branch branch5 = new Branch();
        Branch branch6 = new Branch();

        tree.branches.Add(branch1);
        tree.branches.Add(branch2);
        tree.branches.Add(branch3);
        branch1.branches.Add(branch4);
        branch4.branches.Add(branch5);
        branch5.branches.Add(branch6);

        // Calculating depth of the structure using recursive method
        int depth = CalculateDepth(tree);

        Console.WriteLine("Depth of provided structure: " + depth);
    }

    static int CalculateDepth(Branch branch)
    {
        int structureDepth = 0;

        // case1: structure does not have branches, depth = 1
        if (branch.branches.Count == 0)
        {
            return 1;
        }

        // case2: structure has child branches, finding longest one
        foreach (Branch child in branch.branches)
        {
            int childDepth = CalculateDepth(child);
            if (childDepth > structureDepth)
            {
                structureDepth = childDepth;
            }
        }

        // longest branch + 1 because of the root tree branch
        return ++structureDepth;
    }
}

