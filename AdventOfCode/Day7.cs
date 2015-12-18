using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day7
    {
        enum Gates
        {
            ASSIGN,
            AND,
            OR,
            NOT,
            LSHIFT,
            RSHIFT,
        };

        struct Wire
        {
            public string input1;
            public Gates gate;
            public string input2;
            public string target;
            public UInt16 targetValue;
            public bool processed;
            public int index;
        };

        static Wire[] wires = new Wire[340];

        public static int ProcessDay7(out long count2)
        {
            int count = 0;
            count2 = 0;

            string filePath = "..\\..\\Data\\Day7.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }

                    char[] delimiter = new char[1];
                    delimiter[0] = ' ';
                    string[] instruction = line.Split(delimiter);

                    Wire wire = new Wire();
                    wire.index = count;
                    count++;

                    if (instruction[0] == Gates.NOT.ToString())
                    {
                        wire.input1 = instruction[1];
                        wire.gate = Gates.NOT;
                        wire.target = instruction[3];
                    }
                    else
                    {
                        wire.input1 = instruction[0];

                        if (instruction[1] == "->")
                        {
                            wire.gate = Gates.ASSIGN;
                            wire.target = instruction[2];
                        }
                        else if (instruction[1] == Gates.AND.ToString())
                        {
                            wire.gate = Gates.AND;
                            wire.input2 = instruction[2];
                            wire.target = instruction[4];
                        }
                        else if (instruction[1] == Gates.OR.ToString())
                        {
                            wire.gate = Gates.OR;
                            wire.input2 = instruction[2];
                            wire.target = instruction[4];
                        }
                        else if (instruction[1] == Gates.LSHIFT.ToString())
                        {
                            wire.gate = Gates.LSHIFT;
                            wire.input2 = instruction[2];
                            wire.target = instruction[4];
                        }
                        else if (instruction[1] == Gates.RSHIFT.ToString())
                        {
                            wire.gate = Gates.RSHIFT;
                            wire.input2 = instruction[2];
                            wire.target = instruction[4];
                        }
                        else
                        {
                            System.Diagnostics.Debug.Assert(false, "Invalid command");
                        }
                    }

                    wires[wire.index] = wire;
                }

                // Process wires.
                while (wires.Count(checkWire => checkWire.input1 != null && checkWire.processed == false) > 0)
                {
                    foreach (Wire thisWire in wires.Where(checkWire => checkWire.input1 != null && checkWire.processed == false))
                    {
                        ushort result;
                        // Direct assign
                        if (ushort.TryParse(thisWire.input1, out result) && (result != 0 || thisWire.input1 == "0") && thisWire.gate == Gates.ASSIGN)
                        {
                            wires[thisWire.index].processed = true;
                            wires[thisWire.index].targetValue = result;
                        }
                        else if (thisWire.gate == Gates.ASSIGN)
                        {
                            var found = wires.Where(wire => wire.processed == true && wire.target == thisWire.input1);

                            if (found.Count() > 0)
                            {
                                System.Diagnostics.Debug.Assert(found.Count() == 1);
                                wires[thisWire.index].processed = true;
                                wires[thisWire.index].targetValue = found.First().targetValue;
                            }
                        }
                        else if (thisWire.gate == Gates.NOT)
                        {
                            var found = wires.Where(wire => wire.processed == true && wire.target == thisWire.input1);

                            if (found.Count() > 0)
                            {
                                System.Diagnostics.Debug.Assert(found.Count() == 1);
                                wires[thisWire.index].processed = true;
                                wires[thisWire.index].targetValue = (ushort)~found.First().targetValue;
                            }
                        }
                        else if (thisWire.gate == Gates.LSHIFT)
                        {
                            var found = wires.Where(wire => wire.processed == true && wire.target == thisWire.input1);

                            if (found.Count() > 0)
                            {
                                System.Diagnostics.Debug.Assert(found.Count() == 1);
                                wires[thisWire.index].processed = true;
                                wires[thisWire.index].targetValue = (ushort)(found.First().targetValue << int.Parse(thisWire.input2));
                            }
                        }
                        else if (thisWire.gate == Gates.RSHIFT)
                        {
                            var found = wires.Where(wire => wire.processed == true && wire.target == thisWire.input1);

                            if (found.Count() > 0)
                            {
                                System.Diagnostics.Debug.Assert(found.Count() == 1);
                                wires[thisWire.index].processed = true;
                                wires[thisWire.index].targetValue = (ushort)(found.First().targetValue >> int.Parse(thisWire.input2));
                            }
                        }
                        else if (thisWire.gate == Gates.AND)
                        {
                            if (ushort.TryParse(thisWire.input1, out result))
                            {
                                var found2 = wires.Where(wire => wire.processed == true && wire.target == thisWire.input2);

                                if (found2.Count() > 0)
                                {
                                    System.Diagnostics.Debug.Assert(found2.Count() == 1);

                                    wires[thisWire.index].processed = true;
                                    wires[thisWire.index].targetValue = (ushort)(result & found2.First().targetValue);
                                }
                            }
                            else
                            {
                                var found = wires.Where(wire => wire.processed == true && wire.target == thisWire.input1);

                                if (found.Count() > 0)
                                {
                                    System.Diagnostics.Debug.Assert(found.Count() == 1);

                                    var found2 = wires.Where(wire => wire.processed == true && wire.target == thisWire.input2);

                                    if (found2.Count() > 0)
                                    {
                                        System.Diagnostics.Debug.Assert(found2.Count() == 1);

                                        wires[thisWire.index].processed = true;
                                        wires[thisWire.index].targetValue = (ushort)(found.First().targetValue & found2.First().targetValue);
                                    }
                                }
                            }
                        }
                        else if (thisWire.gate == Gates.OR)
                        {
                            var found = wires.Where(wire => wire.processed == true && wire.target == thisWire.input1);

                            if (found.Count() > 0)
                            {
                                System.Diagnostics.Debug.Assert(found.Count() == 1);

                                var found2 = wires.Where(wire => wire.processed == true && wire.target == thisWire.input2);

                                if (found2.Count() > 0)
                                {
                                    System.Diagnostics.Debug.Assert(found2.Count() == 1);

                                    wires[thisWire.index].processed = true;
                                    wires[thisWire.index].targetValue = (ushort)(found.First().targetValue | found2.First().targetValue);
                                }
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.Assert(false);
                        }
                    }
                }
            }

            var final = wires.Where(wire => wire.target == "a");

            return final.First().targetValue;
        }
    }
}

