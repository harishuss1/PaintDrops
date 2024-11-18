using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib
{
    public class PatternGenerationFactory
    {
        public static IPatternGenerator CreatePhylloPattern(float scalingFactor)
        {
            IPatternGenerator PhyllotaxisPatternGeneration = new PhyllotaxisPatternGeneration(scalingFactor);
            return PhyllotaxisPatternGeneration;
        }
    }
}
