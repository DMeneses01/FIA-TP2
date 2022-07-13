using GeneticSharp.Domain.Chromosomes;
using System;
using System.Linq;
using UnityEngine;
using GeneticSharp.Domain.Randomizations;
using System.Collections.Generic;
using GeneticSharp.Domain.Crossovers;

namespace GeneticSharp.Runner.UnityApp.Commons
{
    public class SinglePointCrossover : ICrossover
    {


        public int ParentsNumber { get; private set; }

        public int ChildrenNumber { get; private set; }

        public int MinChromosomeLength { get; private set; }

        public bool IsOrdered { get; private set; } // indicating whether the operator is ordered (if can keep the chromosome order).

        protected float crossoverProbability;


        public SinglePointCrossover(float crossoverProbability) : this(2, 2, 2, true)
        {
            this.crossoverProbability = crossoverProbability;
        }

        public SinglePointCrossover(int parentsNumber, int offSpringNumber, int minChromosomeLength, bool isOrdered)
        {
            ParentsNumber = parentsNumber;
            ChildrenNumber = offSpringNumber;
            MinChromosomeLength = minChromosomeLength;
            IsOrdered = isOrdered;
        }

        public IList<IChromosome> Cross(IList<IChromosome> parents)
        {
            IChromosome parent1 = parents[0]; //informa��es sobre um pai
            IChromosome parent2 = parents[1]; //informa��es sobre um pai
            IChromosome offspring1 = parent1.CreateNew(); //primeiro filho criado de acordo com o primeiro pai
            IChromosome offspring2 = parent2.CreateNew(); //segundo filho criado de acordo com o segundo pai

            //YOUR CODE HERE

            int i = 0;

            if (RandomizationProvider.Current.GetDouble() <= crossoverProbability)
            {
                int cutPoint = RandomizationProvider.Current.GetInt(1, parent1.Length);

                while (i < cutPoint)
                {
                    offspring1.ReplaceGene(i, parent2.GetGene(i)); //de forma random, s�o colocadas informa��es do segundo pai no primeiro filho
                    offspring2.ReplaceGene(i, parent1.GetGene(i)); //de forma random, s�o colocadas informa��es do primeiro pai no segundo filho
                    i++;
                }
            }



            return new List<IChromosome> { offspring1, offspring2 };
            
        }
    }
}