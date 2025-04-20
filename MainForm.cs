using System.Diagnostics;
using MemoryHacks;
using System.Windows.Forms;
using System.Threading;
using System;
using MetroSuite;

public partial class MainForm : MetroForm
{
    private MemoryHacksLib mem = new MemoryHacksLib("ac_client");
    private IntPtr baseAddress = IntPtr.Zero;

    public MainForm()
    {
        InitializeComponent();
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
        CheckForIllegalCrossThreadCalls = false;
        mem.WriteMethod = MemoryMethod.NTDLL;
        mem.ProtectMethod = MemoryMethod.NTDLL;
        mem.ReadMethod = MemoryMethod.NTDLL;
        baseAddress = (IntPtr) mem.GetAddressFromPointers("0x00183828 0x8 0xB4C 0x98 0x30 0x508");

        Thread thread = new Thread(DoThings);
        thread.Priority = ThreadPriority.Highest;
        thread.Start();
    }

    public void DoThings()
    {
        while (true)
        {
            Thread.Sleep(5);

            if (siticoneCheckBox1.Checked)
            {
                mem.WriteInt32(baseAddress, 1337);
            }

            if (siticoneCheckBox2.Checked)
            {
                mem.WriteInt32(baseAddress - 0x24, 1337);
            }

            if (siticoneCheckBox3.Checked)
            {
                mem.WriteInt32(baseAddress + 0x4, 1337);
            }

            if (siticoneCheckBox4.Checked)
            {
                mem.WriteInt32(baseAddress - 0x54, 1337);
            }

            if (siticoneCheckBox5.Checked)
            {
                mem.WriteInt32(baseAddress - 0x50, 1337);
            }

            if (siticoneCheckBox6.Checked)
            {
                mem.WriteInt32(baseAddress - 0x4, 1337);
            }

            if (siticoneCheckBox7.Checked)
            {
                mem.WriteInt32(baseAddress - 0x28, 1337);
            }

            if (siticoneCheckBox8.Checked)
            {
                mem.WriteInt32(baseAddress - 0x14, 1337);
            }

            if (siticoneCheckBox9.Checked)
            {
                mem.WriteInt32(baseAddress - 0x38, 1337);
            }

            if (siticoneCheckBox10.Checked)
            {
                mem.WriteInt32(baseAddress + 0x24, 1);
            }

            if (siticoneCheckBox13.Checked)
            {
                mem.WriteInt32(baseAddress - 0x10, 1337);
            }

            if (siticoneCheckBox14.Checked)
            {
                mem.WriteInt32(baseAddress - 0x34, 1337);
            }

            if (siticoneCheckBox15.Checked)
            {
                mem.WriteInt32(baseAddress - 0xC, 1337);
            }

            if (siticoneCheckBox16.Checked)
            {
                mem.WriteInt32(baseAddress - 0x30, 1337);
            }

            if (siticoneCheckBox11.Checked)
            {
                mem.WriteInt32(baseAddress - 0x8, 1337);
            }

            if (siticoneCheckBox12.Checked)
            {
                mem.WriteInt32(baseAddress - 0x2C, 1337);
            }

            if (siticoneCheckBox17.Checked)
            {
                mem.WriteInt32(baseAddress + 0x8, 1337);
            }

            if (siticoneCheckBox18.Checked)
            {
                mem.WriteInt32(baseAddress - 0x1C, 1337);
            }
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Process.GetCurrentProcess().Kill();
    }
}