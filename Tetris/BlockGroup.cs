﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
namespace Tetris
{
    class BlockGroup
    {
        private InfoArr info;
        private Color disapperColor;
        private int rectPix;
        public BlockGroup()
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            info = new InfoArr();
            info = config.Info;
            disapperColor = config.BackColor;
            rectPix = config.RectPix;
        }
        public Block GetABlock()//从砖块组中随机抽取一个砖块样式返回
        {
            Random rd = new Random();//声明产生一个随机类
            int keyOrder = rd.Next(0, info.Length);//产生一个随机数
            BitArray ba = info[keyOrder].ID;//把抽取出的砖块样式赋给BitArray类对象ba
            int struNum = 0;     //确定这个砖块样式中被填充方块的个数
            foreach(bool b in ba) //即需要确定Point数组的长度
            {
                if(b)
                {
                    struNum++;
                }
            }
            Point[] structArr = new Point[struNum];//新增一个Point数组，并确定其长度，以创建新的Block
            int k = 0;
            for(int j=0;j<ba.Length;j++)  //用循环给Point数组strucutArr赋坐标值
            {
                if(ba[j])
                {
                    structArr[k].X = j / 5 - 2;
                    structArr[k].Y = 2 - j % 5;
                    k++;
                }
            }
            return new Block(structArr, info[keyOrder].BColor, disapperColor, rectPix); //创建一个新砖块并返回
        }
    }
}
