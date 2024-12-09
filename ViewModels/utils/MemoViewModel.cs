using CodeTools.common.model;
using CodeTools.model;
using CodeTools.utils;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using tools;

namespace CodeTools.ViewModels.utils
{
    public class MemoViewModel : NavigationViewModel
    {

        public MemoViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            load();
            addCommand = new DelegateCommand<Memo>(add);
            removeCommand=new DelegateCommand<Memo>(remove);
            updateCommand = new DelegateCommand<Memo>(update);
            selectCommand = new DelegateCommand<Memo>(select);

        }
        private ObservableCollection<Memo> memos;

        public ObservableCollection<Memo> Memos
        {
            get { return memos; }
            set { memos = value; RaisePropertyChanged(); }
        }

        private Memo curMemo;

        public Memo CurMemo
        {
            get { return curMemo; }
            set { curMemo = value; RaisePropertyChanged(); }
        }


        public DelegateCommand<Memo> addCommand { get; private set; }

        public DelegateCommand<Memo> removeCommand { get; private set; }

        public DelegateCommand<Memo> updateCommand { get; private set; }

        public DelegateCommand<Memo> selectCommand { get; private set; }

        private void load() {
            try
            {
                var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                var dirPath = customizeFunctionFolderPath + "\\nuoqin";
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                    File.SetAttributes(dirPath, directoryInfo.Attributes | FileAttributes.Hidden);
                }
                var jsonFile = customizeFunctionFolderPath + "\\nuoqin\\password_customize.json";
                //判断文件是否存在
                if (!File.Exists(jsonFile))
                {
                    File.WriteAllText(jsonFile, "{\r\n  \"list\":[\r\n     { \"title\":\"QQ\",\"remark\":\"qq账号信息\",\"userName\":\"123456\",\"password\":\"123456\"}\r\n  ]\r\n}");
                }
                string jsonStr = File.ReadAllText(jsonFile, Encoding.UTF8);
                if (string.IsNullOrEmpty(jsonStr))
                {
                    return;
                }
                MemoData data = JsonConvert.DeserializeObject<MemoData>(jsonStr);
                var list = data.List;
                Memos = list;
                if (list.Count > 0) {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].Id = i + 1;
                    }
                    curMemo = Memos[0];
                }
                else
                {
                    curMemo = new Memo();
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载自定义应用失败：" + ex.Message, "错误");
            }

        }


        private void add(Memo memo)
        {
            if (CurMemo.Id.Equals(-1))
            {
                return;
            }
            CurMemo = new Memo();
            CurMemo.Id = -1;

        }
        private void select(Memo memo)
        {

            CurMemo = memo;
        }

        private void update(Memo memo)
        {
            if (CurMemo.Id.Equals(-1))
            {
                memo.Id = Memos.Count;
                Memos.Add(memo);
            }
            else { 
                memos[memo.Id - 1] = memo;
            }
              MessageBox.Show("修改成功！", "success");
            inserFile();
        }

        private void remove(Memo memo)
        {
            Memos.Remove(memo);
            if (Memos.Count > 0)
            {
                CurMemo = Memos[0];
            }
            else
            {
                CurMemo = new Memo();
                CurMemo.Id = -1;
            }
            MessageBox.Show("删除成功！", "success");
            inserFile();
        }


        private void inserFile() {
           var task= Task.Run(() =>
            {
                var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var jsonFile = customizeFunctionFolderPath + "\\password_customize.json";
                MemoData memoData = new MemoData();
                memoData.List = Memos;
                File.WriteAllText(jsonFile, JsonConvert.SerializeObject(memoData));
            });
        }



    }
}
