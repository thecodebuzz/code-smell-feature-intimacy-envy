using System;

namespace WithCodeSmell
{
    class A
    {
        private B _b;
    }

    class B
    {
        private A _a;
    }
}

namespace FixedCodeSmellApporach1
{
    class A
    {
        private B _b;
    }
    class B
    {

    }
}
namespace FixedCodeSmellApporach2
{
    class A
    {
        private B _b;

        A(IClassB classb)
        {
            _b = (B)classb;
        }
    }

    interface IClassB
    {
    }

    class B:IClassB
    {

    }
}
