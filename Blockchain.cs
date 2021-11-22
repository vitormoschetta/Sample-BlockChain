using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Blockchain
{
    public class Blockchain
    {
        private List<Block> Chain;
        public Blockchain()
        {
            InitializeChain();
            AddGenesisBlock();
        }

        private void InitializeChain()
        {
            Chain = new List<Block>();
        }

        private void AddGenesisBlock()
        {
            Chain.Add(new Block(DateTime.Now, null, "{}"));
        }

        private Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public ReadOnlyCollection<Block> GetChain()
        {
            var chain = new ReadOnlyCollection<Block>(Chain);
            return chain;

        }

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.CalculateHash();
            Chain.Add(block);
        }

        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}