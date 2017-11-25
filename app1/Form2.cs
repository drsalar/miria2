using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HtmlAgilityPack;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace app1
{
    public partial class Form1 : Form
    {
        public int current;
        public string userID;
        public string courseID;
        public string currentRows;
        public string startStudyTime;
        public string st;

        public string log;
        public bool studying;
        public bool ssss;
        public bool ffff;

        public string user;
        public string password;
        public string username;
        public System.Net.CookieContainer cc;


        public string domain = "http://www.ulearning.cn";
        public string cmipoxyUrl = "http://www.ulearning.cn/umooc/cmipoxy.do";
        public string heartbeatUrl = "http://www.ulearning.cn/umooc/cmimoocproxyheartbeat.do";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Thread tttt = new Thread(ticketx);
            tttt.Start();
            this.studying = false;
            this.user = Http.user;
            this.password = Http.pwd;
            this.cc = Http.cc;
            this.username = Http.name;
            int i = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[i].Cells[0].Value = this.user;
            this.dataGridView1.Rows[i].Cells[1].Value = this.username;
            this.dataGridView1.Rows[i].Cells[2].Value = "等待中";
            //Control.CheckForIllegalCrossThreadCalls = false;
            this.loadCourses();
        }

        public void ticketx()
        {
            while (true)
            {
                Thread.Sleep(30000);
                this.ffff = false;
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.studying)
            {
                return;
            }
            this.current = 2;
            this.currentRows = "";
            var rows = this.dataGridView2.SelectedRows;

            foreach (DataGridViewRow row in rows)
            {
                if (this.currentRows == "")
                {
                    this.currentRows = row.Cells[0].Value.ToString();
                }
                else
                {
                    this.currentRows = this.currentRows + ", " + row.Cells[0].Value.ToString();
                }
            }
            if (this.log == "")
            {
                this.logTB.Text = this.currentRows;
            }
            else
            {
                this.logTB.Text = this.log + "\r\n" + "当前选中的内容是：" + this.currentRows;
            }

            var link = this.dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            var url = this.domain + link;
            this.loadChapters(url);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.studying)
            {
                return;
            }
            this.current = 3;
            this.currentRows = "";
            var rows = this.dataGridView3.SelectedRows;

            foreach (DataGridViewRow row in rows)
            {
                if (this.currentRows == "")
                {
                    this.currentRows = row.Cells[0].Value.ToString();
                }
                else
                {
                    this.currentRows = this.currentRows + ", " + row.Cells[0].Value.ToString();
                }
            }
            if (this.log == "")
            {
                this.logTB.Text = this.currentRows;
            }
            else
            {
                this.logTB.Text = this.log + "\r\n" + "当前选中的内容是：" + this.currentRows;
            }

            var data = this.dataGridView3.SelectedRows[0].Cells[5].Value.ToString();
            string link = this.genLessionUrl(data);

            var url = this.domain + link;
            this.loadLessions(url);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.studying)
            {
                return;
            }
            this.current = 4;
            this.currentRows = "";
            var rows = this.dataGridView4.SelectedRows;

            foreach (DataGridViewRow row in rows)
            {
                if (this.currentRows == "")
                {
                    this.currentRows = row.Cells[0].Value.ToString();
                }
                else
                {
                    this.currentRows = this.currentRows + ", " + row.Cells[0].Value.ToString();
                }
            }
            if (this.log == "")
            {
                this.logTB.Text = this.currentRows;
            }
            else
            {
                this.logTB.Text = this.log + "\r\n" + "当前选中的内容是：" + this.currentRows;
            }
        }

        private void startBt_Click(object sender, EventArgs e)
        {
            this.studying = true;
            this.dataGridView1.Rows[0].Cells[2].Value = "学习中";
            if (this.log == "")
            {
                this.log = this.currentRows;
            }
            else
            {
                this.log = this.log + "\r\n" + "当前选中的内容是：" + this.currentRows;
            }
            this.log = this.log + "\r\n" + "执行以下选中内容：" + this.currentRows;
            this.logTB.Text = this.log;

            if (this.current == 4)
            {
                var rows = this.dataGridView4.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    string link = row.Cells[7].Value.ToString();
                    string pc = row.Cells[1].Value.ToString();
                    string itemId = row.Cells[8].Value.ToString();
                    string nodeId = row.Cells[9].Value.ToString();
                    string lession = row.Cells[0].Value.ToString();
                    string pn = row.Cells[2].Value.ToString();
                    if (row.Cells[5].Value.ToString() == "完成")
                    {
                        //continue;
                    }
                    this.studyLession(itemId, nodeId, link, lession, pn, false, int.Parse(pc));

                }
            }
            else if (this.current == 3)
            {
                this.studyChapter(true);
            }
            else if (this.current == 2)
            {
                var rows = this.dataGridView2.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    string course = row.Cells[0].Value.ToString();
                    string url = this.domain + row.Cells[5].Value.ToString();

                    this.log = this.log + "\r\n" + "课程：" + course;
                    this.logTB.Text = this.log;

                    this.loadChapters(url);

                    this.studyChapter(false);

                    this.log = this.log + "\r\n" + "课程：" + course + " ······完成";
                    this.logTB.Text = this.log;
                }
            }
            this.studying = false;
            this.dataGridView1.Rows[0].Cells[2].Value = "学习结束";
        }



        public void loadCourses()
        {
            string postdata = "operation=catalog&lang=zh&catalogID=0&year=0";
            string req = Http.HttpPost("http://www.ulearning.cn/umooc/learner/study.do?operation=catalog&lang=zh", postdata);

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(req);

            var nodes = doc.DocumentNode.SelectNodes("//*/div[@class='course-detail left']");
            foreach (var node in nodes)
            {
                var x1 = node.SelectSingleNode("./h3 ").InnerText;
                if (!x1.Contains("Market Leader Interactive") && !x1.Contains("Academic Connections") && !x1.Contains("大学英语实用技能"))
                {
                    continue;
                }
                var x2 = node.SelectSingleNode("./div/div/span[@class='progress-pre left']").InnerText;
                var x3 = node.SelectSingleNode("./div[@class='mr10 info-block']").InnerText.Trim('\r').Trim('\n').Trim('\t').Trim('\n').Trim('\r');
                var x4 = node.SelectSingleNode("./div[@class='info-block']").InnerText.Trim('\r').Trim('\n').Trim('\t');
                x4 = x4.Substring(0, x4.IndexOf('\r'));
                var x5 = "调试中";
                var n = node.SelectSingleNode("./a");
                var attrs = node.SelectSingleNode("./a").Attributes;
                var x6 = "/";
                foreach (var attr in attrs)
                {
                    if (attr.Name == "href")
                    {
                        x6 = attr.Value.ToString();
                        break;
                    }
                }
                int i = this.dataGridView2.Rows.Add();
                this.dataGridView2.Rows[i].Cells[0].Value = x1;
                this.dataGridView2.Rows[i].Cells[1].Value = x2;
                this.dataGridView2.Rows[i].Cells[2].Value = x3;
                this.dataGridView2.Rows[i].Cells[3].Value = x4;
                this.dataGridView2.Rows[i].Cells[4].Value = x5;
                this.dataGridView2.Rows[i].Cells[5].Value = x6;
            }
        }

        public void loadChapters(string url)
        {
            var req = Http.HttpGet(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(req);

            var nodes = doc.DocumentNode.SelectNodes("//*/tr[@class='thecuorse']");
            if (nodes != null)
            {
                this.dataGridView3.Rows.Clear();
                foreach (var node in nodes)
                {
                    var x1 = node.SelectSingleNode("./td/div/p").InnerText;
                    x1 = x1.Substring(30);
                    x1 = x1.Substring(0, x1.IndexOf('\r'));
                    var x2 = node.SelectSingleNode("./td/span[@class='progress-pre course-over']").InnerText;
                    x2 = x2.Substring(x2.LastIndexOf(';') + 1);
                    var x3 = node.SelectSingleNode("./td/span[@class='course-over']").InnerText;
                    var x4 = node.SelectSingleNode("./td/span[@class='course-over  title gray']").InnerText;
                    var x5 = "学习中";
                    var n = node.SelectSingleNode("./td/div[@class='btn-primary title tsize14']");
                    var attrs = n.Attributes;
                    var x6 = "/";
                    foreach (var attr in attrs)
                    {
                        if (attr.Name == "onclick")
                        {
                            x6 = attr.Value.ToString();
                            break;
                        }
                    }
                    x6 = x6.Substring(x6.IndexOf('(') + 1);
                    x6 = x6.Substring(0, x6.IndexOf(')'));
                    string[] xxx = x6.Split(',');
                    if (xxx[5].Trim(' ') == "8")
                    {
                        continue;
                    }
                    int i = this.dataGridView3.Rows.Add();
                    this.dataGridView3.Rows[i].Cells[0].Value = x1;
                    this.dataGridView3.Rows[i].Cells[1].Value = x2;
                    this.dataGridView3.Rows[i].Cells[2].Value = x3;
                    this.dataGridView3.Rows[i].Cells[3].Value = x4;
                    this.dataGridView3.Rows[i].Cells[4].Value = x5;
                    this.dataGridView3.Rows[i].Cells[5].Value = x6;
                }
            }
        }

        public void loadLessions(string url)
        {
            string req = Http.HttpGet(url);

            this.userID = req.Substring(req.IndexOf("setUserID") + 11);
            this.userID = this.userID.Substring(0, this.userID.IndexOf('"'));

            this.courseID = req.Substring(req.IndexOf("setCourseID(") + 13);
            this.courseID = this.courseID.Substring(0, this.courseID.IndexOf('"'));

            string data = req.Substring(req.IndexOf("\"list\":") + 7);
            data = data.Substring(0, data.IndexOf(']') + 1);
            if (data == null || data == "")
            {
                this.logTB.Text = this.log + "\r\n当前正在学习其他页面，请退出";
                return;
            }
            JArray ja = (JArray)JsonConvert.DeserializeObject(data);
            this.dataGridView4.Rows.Clear();
            foreach (var j in ja)
            {
                var x0 = j["activityTitle"].ToString();
                var x1 = j["totalNum"].ToString();
                var x2 = j["practiceNum"].ToString();
                var x3 = j["studyTime"].ToString();
                var x4 = j["score"].ToString();
                var x5 = j["completed"].ToString();
                var x6 = "学习中";
                var x7 = j["link"].ToString();
                var x8 = j["itemID"].ToString();
                var x9 = j["nodeID"].ToString();
                int i = this.dataGridView4.Rows.Add();
                this.dataGridView4.Rows[i].Cells[0].Value = x0;
                this.dataGridView4.Rows[i].Cells[1].Value = x1;
                this.dataGridView4.Rows[i].Cells[2].Value = x2;
                this.dataGridView4.Rows[i].Cells[3].Value = x3;
                this.dataGridView4.Rows[i].Cells[4].Value = x4;
                if (x5.ToLower() == "true")
                {
                    x5 = "完成";
                }
                else
                {
                    x5 = "未完成";
                }
                this.dataGridView4.Rows[i].Cells[5].Value = x5;
                this.dataGridView4.Rows[i].Cells[6].Value = x6;
                this.dataGridView4.Rows[i].Cells[7].Value = x7;
                this.dataGridView4.Rows[i].Cells[8].Value = x8;
                this.dataGridView4.Rows[i].Cells[9].Value = x9;
            }
        }



        public string genLessionUrl(string data)
        {
            string link = "";
            var xs = data.Split(',');
            if (xs.Length == 7)
            {
                if (xs[5] == "8")
                {
                    link = "/umooc/learner/study.do?operation=detectEnvironment&paperID=" + xs[6].Trim(' ') + "&nodeID=" + xs[0].Trim(' ') + "&courseID=" + xs[1].Trim(' ') + "&fw=examCourse";
                    return "";
                }
                else
                {
                    switch (xs[2].Trim(' '))
                    {
                        case "7":
                            link = "/umooc/user/study.do?operation=openPaperFromOrg&fw=org&examID=" + xs[2].Trim(' ');
                            break;
                        case "8":
                            link = "/umooc/learner/homework.do?operation=homeworkDetail&id=" + xs[2].Trim(' ');
                            break;
                        case "2":
                            link = "/umooc/learner/moocStudy.do?operation=startStudy&inUCC=" + xs[4].Trim(' ') + "&nodeID=" + xs[0].Trim(' ') + "&courseID=" + xs[1].Trim(' ');
                            break;
                        default:
                            link = "/umooc/learner/study.do?operation=startStudy&nodeID=" + xs[0].Trim(' ') + "&courseID=" + xs[1].Trim(' ') + "&inUCC=" + xs[4].Trim(' ');
                            break;
                    }
                }


            }
            else
            {
                return "";
            }
            return link;
        }

        public void studyLession(string itemId, string nodeId, string link, string lession, string pn, bool fax, int pageCount)
        {
            this.log = this.log + "\r\n" + "开始答题：" + lession;
            this.logTB.Text = this.log;
            this.heartbeat();

            string landingdata = this.landing(link);
            string startpage = landingdata.Substring(landingdata.IndexOf("startpage = ") + 13);
            startpage = startpage.Substring(0, startpage.IndexOf('\''));
            string prlink = link.Substring(0, link.IndexOf('?'));
            prlink = prlink.Substring(0, prlink.LastIndexOf('/'));
            string homepage = prlink.Substring(prlink.LastIndexOf('/'));
            string prlink2 = prlink.Substring(0, prlink.LastIndexOf('/'));

            string courseData = this.initandcontent(prlink2);

            string req = this.cmipoxy(itemId, nodeId, lession, "Initialize", "");
            string sst = req.Substring(req.IndexOf("systime") + 9);
            sst = sst.Substring(0, sst.IndexOf(','));
            this.startStudyTime = sst;
            this.st = sst;

            int i = 0;
            int j = 0;
            int pageIndex = 1;
            int cn = int.Parse(pn);
            //string ll = "\"cmi#interactions.0.learner_record\":\"[]\"";
            string ll = ",\"cmi#interactions.0.learner_record\":\"[]\"";
            string jkl = ",\"cmi#interactions.0.learner_record\":\"[]\"";
            string ppp = "";
            while (true)
            {
                bool xaxa = true;
                j++;
                this.heartbeat(1, itemId);
                try
                {
                    string pg = this.loadpage(prlink + "/" + startpage, "");

                    int ct = int.Parse(this.st);
                    //int et = ct;
                    //et -= 60 * 5;
                    ct += 60 * 5;
                    string cts = ct.ToString() + "234";
                    this.loadpage(prlink + "/" + startpage, "_=" + cts);
                    string qq = "";
                    if (pg.Contains("correctAnswer"))
                    {
                        xaxa = false;
                        //TODO
                        //for (i = 0; i < cn; i++)
                        //{
                        string type = pg.Substring(pg.IndexOf("questionType") + 17);
                        type = type.Substring(0, type.IndexOf(']'));
                        string[] types = type.Split(',');
                        string qestid = pg.Substring(pg.IndexOf("qsetID=") + 8);
                        qestid = qestid.Substring(0, qestid.IndexOf('"'));
                        ll = ll + ",\"cmi#interactions." + (i + 1).ToString() + ".learner_record\":\"[]\",\"cmi.interactions." + i.ToString() + ".description\":\"Activity Data\",\"cmi.interactions." + i.ToString() + ".type\":\"other\",\"cmi.interactions." + i.ToString() + ".id\":\"" + qestid + "\",";
                        ll = ll + "\"cmi.interactions." + i.ToString() + ".learner_response\":\"" + qestid + ";2:1:false:43:2";
                        jkl = "\"cmi#interactions.0.learner_record\":\"[]\",\"cmi.interactions.0.description\":\"Activity Data\",\"cmi.interactions.0.type\":\"other\",\"cmi.interactions.0.id\":\"" + qestid + "\"," + "\"cmi.interactions.0.learner_response\":\"" + qestid + ";2:1:false";
                        string a = pg.Substring(pg.IndexOf("questionId"));
                        a = a.Substring(a.IndexOf('[') + 1);
                        a = a.Substring(0, a.IndexOf(']'));
                        a = a.Replace(" ", "");
                        string[] questionId = a.Split(',');
                        for (int k = 0; k < questionId.Length; k++)
                        {
                            questionId[k] = questionId[k].Substring(questionId[k].IndexOf('"'));
                        }

                        for (int z = 0; z < types.Length; z++)
                        {
                            questionId[z] = questionId[z].Trim('"');
                            types[z] = types[z].Substring(types[z].IndexOf('"'));
                            if (types[z] == "pd" || types[z] == "mcss")
                            {
                                string b = pg.Substring(pg.IndexOf("correctAnswer"));
                                b = b.Substring(b.IndexOf("[[") + 2);
                                b = b.Substring(0, b.IndexOf("]]"));
                                string[] correctAnswer = b.Split(']');
                                for (int k = 1; k < correctAnswer.Length; k++)
                                {
                                    correctAnswer[k] = correctAnswer[k].Trim(',').Trim('[');
                                }
                                string c = pg.Substring(pg.IndexOf("choiceId"));
                                c = c.Substring(c.IndexOf("[[") + 2);
                                if (c.Contains("]]"))
                                {
                                    c = c.Substring(0, c.IndexOf("]]"));
                                }
                                else if (c.Contains("];"))
                                {
                                    c = c.Substring(0, c.IndexOf("];"));
                                }
                                string[] choiceId = c.Split(']');
                                for (int k = 1; k < correctAnswer.Length; k++)
                                {
                                    choiceId[k] = choiceId[k].Substring(choiceId[k].IndexOf('[') + 1);
                                }


                                string[] ca = correctAnswer[z].Split(',');
                                string[] cb = choiceId[z].Split(',');
                                string caa = "";
                                for (int l = 0; l < ca.Length; l++)
                                {
                                    if (ca[l] == "1")
                                    {
                                        caa = cb[l].Trim('"');
                                        break;
                                    }
                                }
                                qq = qq + ";" + questionId[z] + ":" + caa + ":1";
                                ppp = ppp + ";" + questionId[z] + ":" + caa + ":1";
                            }
                            else if (types[z] == "fidd")
                            {
                                string gapx = pg.Substring(pg.IndexOf("gapId" + questionId[z]));
                                gapx = gapx.Substring(gapx.IndexOf('[') + 1);
                                gapx = gapx.Substring(0, gapx.IndexOf(']'));
                                string[] gaps = gapx.Split(',');
                                for (int y = 0; y < gaps.Length; y++)
                                {
                                    gaps[y] = gaps[y].Substring(gaps[y].IndexOf('"') + 1);
                                    gaps[y] = gaps[y].Trim('"');
                                    qq = qq + ";" + gaps[y] + ":" + gaps[y] + "_0" + ":1";
                                    ppp = ppp + ";" + gaps[y] + ":" + gaps[y] + "_0" + ":1";
                                }
                            }
                            else if (types[z] == "ti" || types[z] == "es")
                            {
                                string ans = courseData.Substring(courseData.IndexOf(questionId[z]));
                                ans = ans.Substring(ans.IndexOf("\",\"") + 3);
                                ans = ans.Substring(0, ans.IndexOf("\","));
                                qq = qq + ";" + questionId[z] + ":" + ans + ":1";
                                ppp = ppp + ";" + questionId[z] + ":" + ans + ":1";
                            }
                        }



                        ll = ll + qq + "\"";
                        i++;

                        string data = "{\"relationid\":\"100851100\",\"cmi.learner_name\":\"" + this.username + "\",\"cmi.learner_id\":\"" + this.userID + "\",\"cmi.activity_title\":\"" + lession + "\",\"ulms.node_id\":" + nodeId + ",\"ulms.item_id\":" + itemId + ",\"startStudyTime\":" + this.st + ",\"systime\":" + this.st + ",\"cmi.location\":\"" + pageIndex.ToString() + ":../.." + homepage + "/" + startpage + "\",\"ulms.customized\":0,\"cmi.exit\":\"suspend\",\"cmi.session_time\":\"\"" + ll + "}";
                        string ret = this.cmipoxy(itemId, nodeId, lession, "Commit", data);
                    }
                }
                catch (Exception e)
                {
                    pageIndex++;
                }
                if (pageIndex < pageCount)
                {
                    pageIndex++;
                    string pi = pageIndex.ToString();
                    if (pageIndex < 10)
                    {
                        pi = "0" + pi;
                    }
                    startpage = startpage.Substring(0, startpage.LastIndexOf('_') + 1) + pi + ".html";
                    //int curr = int.Parse(startpage.Substring(startpage.LastIndexOf('_') + 1, startpage.IndexOf('.'))) + 1;
                    //startpage = startpage.Substring(0, startpage.LastIndexOf('_') + 1) + curr.ToString() + ".html";
                    //startpage = pg.Substring(pg.LastIndexOf(".." + homepage) + homepage.Length + 3);
                    //startpage = startpage.Substring(0, startpage.IndexOf('.') + 4);
                }
                else
                {
                    if (fax)
                    {
                        Thread.SpinWait(10000);
                    }
                    string rqq = Http.HttpGet(this.domain + "/umooc/learner/study.do?operation=delStudyMemcache&ciphertext=");
                    string queryd = "/umooc/learner/study.do?operation=loadStudyReport&nodeID=" + nodeId + "&courseID=" + this.courseID + "&inUCC=1&nodeTitle=" + lession.Replace(' ', '+');
                    rqq = Http.HttpGet(this.domain + queryd);
                    string data = "{\"relationid\":\"100851100\",\"cmi.learner_name\":\"" + this.username + "\",\"cmi.learner_id\":\"" + this.userID + "\",\"cmi.activity_title\":\"" + lession + "\",\"ulms.node_id\":" + nodeId + ",\"ulms.item_id\":" + itemId + ",\"startStudyTime\":" + this.st + ",\"systime\":" + this.st + ",\"cmi.location\":\"" + startpage + "\",\"ulms.customized\":0,\"cmi.exit\":\"suspend\",\"cmi.score.raw\":\"100\",\"cmi.completion_status\":\"completed\"" + ll + "}";
                    //this.cmipoxy(itemId, nodeId, lession, "Commit", data);
                    string data2 = "{\"relationid\":\"100851100\",\"cmi.learner_name\":\"" + this.username + "\",\"cmi.learner_id\":\"" + this.userID + "\",\"cmi.activity_title\":\"" + lession + "\",\"ulms.node_id\":" + nodeId + ",\"ulms.item_id\":" + itemId + ",\"startStudyTime\":" + this.st + ",\"systime\":" + this.st + ",\"cmi.location\":\"" + startpage + "\",\"ulms.customized\":0,\"cmi.exit\":\"suspend\",\"cmi.score.raw\":\"100\",\"cmi.completion_status\":\"completed\"," + jkl + ppp + "\"}";
                    if (lession.Contains("Test") || lession.Contains("QUIZ"))
                    {
                        this.cmipoxy(itemId, nodeId, lession, "Commit", data2);
                    }
                    else
                    {
                        this.cmipoxy(itemId, nodeId, lession, "Commit", data);
                    }
                    this.cmipoxy(itemId, nodeId, lession, "Terminate", data);
                    //string req2 = Http.HttpGet(this.domain + "/umooc/learner/study.do?operation=studyReport&courseID=" + this.courseID);
                    break;
                }
            }
            //this.heartbeat(1, itemId);

            this.log = this.log + " ······" + "完成";
            this.logTB.Text = this.log;
        }

        public void studyChapter(bool flag)
        {
            if (flag)
            {
                foreach (DataGridViewRow row in this.dataGridView3.SelectedRows)
                {
                    this.rowHelper(row);
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dataGridView3.Rows)
                {
                    if (row.Index == this.dataGridView3.RowCount - 1)
                    {
                        break;
                    }
                    this.rowHelper(row);
                }
            }
        }

        public void rowHelper(DataGridViewRow row)
        {
            string chapter = row.Cells[0].Value.ToString();
            string data = row.Cells[5].Value.ToString();
            string url = this.domain + this.genLessionUrl(data);
            this.loadLessions(url);

            this.log = this.log + "\r\n" + "章节：" + chapter;
            this.logTB.Text = this.log;

            foreach (DataGridViewRow row2 in this.dataGridView4.Rows)
            {
                if (row2.Index == this.dataGridView4.RowCount - 1)
                {
                    break;
                }
                string link = row2.Cells[7].Value.ToString();
                string pc = row2.Cells[1].Value.ToString();
                string itemId = row2.Cells[8].Value.ToString();
                string nodeId = row2.Cells[9].Value.ToString();
                string lession = row2.Cells[0].Value.ToString();
                string pn = row2.Cells[2].Value.ToString();
                if (row2.Cells[5].Value.ToString() == "完成")
                {
                    continue;
                }
                this.studyLession(itemId, nodeId, link, lession, pn, false, int.Parse(pc));
            }

            this.loadLessions(url);
            this.log = this.log + "\r\n" + "章节：" + chapter + " ······完成";
            this.logTB.Text = this.log;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void logTB_TextChanged(object sender, EventArgs e)
        {
            this.logTB.Select(this.logTB.TextLength, 0);
            this.logTB.ScrollToCaret();
        }


        public string landing(string link)
        {
            return Http.HttpGet(this.domain + link);
        }

        public string initandcontent(string prlink)
        {
            string req = Http.HttpGet(this.domain + prlink + "/shared/common/init.htm");
            req = Http.HttpGet(this.domain + prlink + "/shared/common/content.htm");
            req = Http.HttpGet(this.domain + prlink + "/shared/js/metadata/coursedata.js");
            return req;
        }

        public string cmipoxy(string itemID, string nodeID, string lession, string key, string data)
        {
            if (data == "")
            {
                data = "{\"cmi.learner_name\":\"" + this.username + "\",\"cmi.learner_id\":\"" + this.userID + "\",\"cmi.activity_title\":\"" + lession + "\",\"ulms.node_id\":" + nodeID + ",\"ulms.item_id\":" + itemID + ",\"ulms.customized\":0}";
            }
            //string data2 = "{\"cmi#interactions.0.learner_record\":\"[]\",\"cmi#interactions.1.learner_record\":\"[]\",\"cmi#interactions.2.learner_record\":\"[]\",\"cmi.activity_title\":\"LISTENING\",\"cmi.completion_status\":\"incomplete\",\"cmi.exit\":\"suspend\",\"cmi.interactions.0.description\":\"Activity Data\",\"cmi.interactions.0.id\":\"A3_LI_006_QS\",\"cmi.interactions.0.learner_response\":\"A3_LI_006_QS;0:0:false;q1025186461671_0:-1:0;q1025186461671_1:-1:0;q1025186461671_2:-1:0;q1025186461671_3:-1:0\",\"cmi.interactions.0.type\":\"other\",\"cmi.interactions.1.description\":\"Activity Data\",\"cmi.interactions.1.id\":\"A3_LI_005_QS\",\"cmi.interactions.1.learner_response\":\"A3_LI_005_QS;0:0:false;q1025186461125:-1:0;q1025186461187:-1:0;q1025186461250:-1:0;q1025186461312:-1:0\",\"cmi.interactions.1.type\":\"other\",\"cmi.learner_id\":\"3354489\",\"cmi.learner_name\":\"???\",\"relationid\":\"100851100\",\"startStudyTime\":1508429581,\"ulms.customized\":0,\"ulms.item_id\":253715,\"ulms.node_id\":2121035,\"cmi.interactions.2.id\":\"A3_LI_003_QS\",\"cmi.interactions.2.type\":\"other\",\"cmi.interactions.2.description\":\"Activity Data\",\"cmi.interactions.2.learner_response\":\"A3_LI_003_QS;0:0:false;q1025186460687_0:-1:0;q1025186460687_1:-1:0;q1025186460687_2:-1:0;q1025186460687_3:-1:0\",\"cmi.location\":\"p1025186459937.htm\",\"systime\":1508429653,\"cmi.interactions.3.id\":\"A3_LI_002_QS\",\"cmi.interactions.3.type\":\"other\",\"cmi.interactions.3.description\":\"Activity Data\",\"cmi.interactions.3.learner_response\":\"A3_LI_002_QS;2:2:false;q1025186460140:qa1032892713593:1;q1025186460203:qa1025276077765:1;q1025186460265:qa1025276090437:1;q1025186460328:qa1025276102828:1\",\"cmi.session_time\":\"\"}";
            string data2 = "{\"cmi.activity_title\":\"LISTENING\",\"cmi.completion_status\":\"incomplete\",\"cmi.exit\":\"suspend\",\"cmi.learner_id\":\"3354489\",\"cmi.learner_name\":\"???\",\"relationid\":\"100851100\",\"startStudyTime\":1508429581,\"ulms.customized\":0,\"ulms.item_id\":253715,\"ulms.node_id\":2121035,\"cmi.location\":\"p1025186459937.htm\",\"systime\":1508429653,\"cmi.interactions.0.id\":\"A3_LI_002_QS\",\"cmi.interactions.0.type\":\"other\",\"cmi.interactions.0.description\":\"Activity Data\",\"cmi.interactions.0.learner_response\":\"A3_LI_002_QS;2:2:false;q1025186460140:qa1032892713593:1;q1025186460203:qa1025276077765:1;q1025186460265:qa1025276090437:1;q1025186460328:qa1025276102828:1\",\"cmi.session_time\":\"\"}";
            //string data2 = "{\"cmi.activity_title\":\"LISTENING\",\"cmi.completion_status\":\"incomplete\",\"cmi.exit\":\"suspend\",\"cmi.interactions.1.description\":\"Activity Data\",\"cmi.interactions.1.id\":\"A3_LI_006_QS\",\"cmi.interactions.1.learner_response\":\"A3_LI_006_QS;0:0:false;q1025186461671_0:-1:0;q1025186461671_1:-1:0;q1025186461671_2:-1:0;q1025186461671_3:-1:0\",\"cmi.interactions.1.type\":\"other\",\"cmi.interactions.0.description\":\"Activity Data\",\"cmi.interactions.0.id\":\"A3_LI_005_QS\",\"cmi.interactions.0.learner_response\":\"A3_LI_005_QS;0:0:false;q1025186461125:-1:0;q1025186461187:-1:0;q1025186461250:-1:0;q1025186461312:-1:0\",\"cmi.interactions.0.type\":\"other\",\"cmi.learner_id\":\"3354489\",\"cmi.learner_name\":\"???\",\"relationid\":\"100851100\",\"startStudyTime\":1508429581,\"ulms.customized\":0,\"ulms.item_id\":253715,\"ulms.node_id\":2121035,\"cmi.interactions.2.id\":\"A3_LI_003_QS\",\"cmi.interactions.2.type\":\"other\",\"cmi.interactions.2.description\":\"Activity Data\",\"cmi.interactions.2.learner_response\":\"A3_LI_003_QS;0:0:false;q1025186460687_0:-1:0;q1025186460687_1:-1:0;q1025186460687_2:-1:0;q1025186460687_3:-1:0\",\"cmi.location\":\"p1025186459937.htm\",\"systime\":1508429653,\"cmi.interactions.3.id\":\"A3_LI_002_QS\",\"cmi.interactions.3.type\":\"other\",\"cmi.interactions.3.description\":\"Activity Data\",\"cmi.interactions.3.learner_response\":\"A3_LI_002_QS;2:2:false;q1025186460140:qa1032892713593:1;q1025186460203:qa1025276077765:1;q1025186460265:qa1025276090437:1;q1025186460328:qa1025276102828:1\",\"cmi.session_time\":\"\"}";
            string postData = "postKey=" + key + "&errcode=null&mUserID=" + this.userID + "&mUserName=" + this.username + "&mCourseID=" + this.courseID + "&postData=" + data;
            string req = Http.HttpPost(this.cmipoxyUrl, postData);
            return req;
        }

        public string loadpage(string url, string data)
        {
            if (data == "")
            {
                return Http.HttpGet(this.domain + url);
            }
            else
            {
                return Http.HttpGet(this.domain + url + "?" + data);
            }
        }
        public void heartbeat(int times, string itemID)
        {
            //int t = int.Parse(this.st);
            for (int i = 0; i < times; i++)
            {
                //t += 5;
                //this.st = t.ToString();
                string postData = "itemID=" + itemID + "&userID=" + this.userID + "&systime=" + this.st;
                Http.HttpPost(this.heartbeatUrl, postData);
            }
        }

        public void heartbeat()
        {
            string req = Http.HttpPost(this.heartbeatUrl, "userID=" + this.userID);
        }

        private void stopBt_Click(object sender, EventArgs e)
        {
            if (this.studying)
            {
                this.studying = false;
                this.ssss = false;
                this.dataGridView1.Rows[0].Cells[2].Value = "等待中";
                this.stopBt.Text = "开始挂学时";
                this.stopBt.Enabled = false;
                //this.dataGridView2.Enabled = true;
                //this.dataGridView3.Enabled = true;
                //this.dataGridView4.Enabled = true;
                this.log = this.log + "\r\n" + "正在停止挂学时......";
                this.logTB.Text = this.log;
            }
            else
            {
                this.studying = true;
                this.ssss = true;
                this.dataGridView1.Rows[0].Cells[2].Value = "挂学时中";
                this.stopBt.Text = "停止挂学时";
                this.dataGridView2.Enabled = false;
                this.dataGridView3.Enabled = false;
                this.dataGridView4.Enabled = false;
                if (this.log == "")
                {
                    this.log = this.currentRows;
                }
                else
                {
                    this.log = this.log + "\r\n" + "当前选中的内容是：" + this.currentRows;
                }
                this.log = this.log + "\r\n" + "执行以下选中内容：" + this.currentRows;
                this.logTB.Text = this.log;

                Thread t1 = new Thread(new ThreadStart(tslalala));
                t1.Start();
            }
        }

        private delegate void xsxsx();

        public void tslalala()
        {
            xsxsx xaa = new xsxsx(lalala);
            this.Invoke(xaa);
        }

        public void lalala()
        {
            int times = int.Parse(this.timeTB.Text);
            if (this.current == 4)
            {
                var rows = this.dataGridView4.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    string link = row.Cells[7].Value.ToString();
                    string itemId = row.Cells[8].Value.ToString();
                    string nodeId = row.Cells[9].Value.ToString();
                    string lession = row.Cells[0].Value.ToString();
                    string pn = row.Cells[2].Value.ToString();
                    if (this.ssss)
                    {
                        this.lululu(itemId, nodeId, link, lession, pn, times);
                        //this.studyLession(itemId, nodeId, link, lession, pn, true);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (this.current == 3)
            {
                DataGridViewSelectedRowCollection rows = this.dataGridView3.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    string chapter = row.Cells[0].Value.ToString();
                    string data = row.Cells[5].Value.ToString();
                    string url = this.domain + this.genLessionUrl(data);
                    this.loadLessions(url);

                    this.log = this.log + "\r\n" + "章节：" + chapter;
                    this.logTB.Text = this.log;
                    int tttt = times;
                    if (chapter[0] != 'A' && chapter[0] != 'B' && chapter[0] != 'C')
                    {
                        tttt *= 1;
                    }
                    foreach (DataGridViewRow row2 in this.dataGridView4.Rows)
                    {
                        if (row2.Index == this.dataGridView4.RowCount - 1)
                        {
                            break;
                        }
                        string link = row2.Cells[7].Value.ToString();
                        string itemId = row2.Cells[8].Value.ToString();
                        string nodeId = row2.Cells[9].Value.ToString();
                        string lession = row2.Cells[0].Value.ToString();
                        string pn = row2.Cells[2].Value.ToString();
                        if (this.ssss)
                        {
                            this.lululu(itemId, nodeId, link, lession, pn, tttt);
                            //this.studyLession(itemId, nodeId, link, lession, pn, true);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (!this.ssss)
                    {
                        break;
                    }
                    this.log = this.log + "\r\n" + "章节：" + chapter + " ······完成";
                    this.logTB.Text = this.log;
                }
            }
            else if (this.current == 2)
            {
                var rows = this.dataGridView2.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    string course = row.Cells[0].Value.ToString();
                    string url = this.domain + row.Cells[5].Value.ToString();

                    this.log = this.log + "\r\n" + "课程：" + course;
                    this.logTB.Text = this.log;

                    this.loadChapters(url);

                    DataGridViewRowCollection rows3 = this.dataGridView3.Rows;
                    foreach (DataGridViewRow row2 in rows3)
                    {
                        if (row2.Index == this.dataGridView3.RowCount - 1)
                        {
                            break;
                        }
                        string chapter = row2.Cells[0].Value.ToString();
                        string data = row2.Cells[5].Value.ToString();
                        string url2 = this.domain + this.genLessionUrl(data);
                        this.loadLessions(url2);

                        this.log = this.log + "\r\n" + "章节：" + chapter;
                        this.logTB.Text = this.log;
                        int tttt = times;
                        if (chapter[0] != 'A' && chapter[0] != 'B' && chapter[0] != 'C')
                        {
                            tttt *= 1;
                        }
                        foreach (DataGridViewRow row4 in this.dataGridView4.Rows)
                        {
                            if (row4.Index == this.dataGridView4.RowCount - 1)
                            {
                                break;
                            }
                            string link = row4.Cells[7].Value.ToString();
                            string itemId = row4.Cells[8].Value.ToString();
                            string nodeId = row4.Cells[9].Value.ToString();
                            string lession = row4.Cells[0].Value.ToString();
                            string pn = row4.Cells[2].Value.ToString();
                            if (this.ssss)
                            {
                                this.lululu(itemId, nodeId, link, lession, pn, tttt);
                                //this.studyLession(itemId, nodeId, link, lession, pn, true);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (!this.ssss)
                        {
                            break;
                        }
                        this.log = this.log + "\r\n" + "章节：" + chapter + " ······完成";
                        this.logTB.Text = this.log;
                    }
                    if (!this.ssss)
                    {
                        break;
                    }
                    this.log = this.log + "\r\n" + "课程：" + course + " ······完成";
                    this.logTB.Text = this.log;
                }
            }
            this.studying = false;
            this.ssss = false;
            this.dataGridView2.Enabled = true;
            this.dataGridView3.Enabled = true;
            this.dataGridView4.Enabled = true;
            this.dataGridView1.Rows[0].Cells[2].Value = "等待中";
            this.log = this.log + "\r\n" + "完成挂学时";
            this.logTB.Text = this.log;
            this.stopBt.Text = "开始挂学时";
            this.stopBt.Enabled = true;
        }

        public void lululu(string itemId, string nodeId, string link, string lession, string pn, int times)
        {
            this.log = this.log + "\r\n" + "开始挂学时：" + lession + "......";
            this.logTB.Text = this.log;
            this.heartbeat();

            string landingdata = this.landing(link);
            string startpage = landingdata.Substring(landingdata.LastIndexOf("startpage = ") + 13);
            startpage = startpage.Substring(0, startpage.IndexOf('\''));

            string prlink = link.Substring(0, link.IndexOf('?'));
            prlink = prlink.Substring(0, prlink.LastIndexOf('/'));
            string homepage = prlink.Substring(prlink.LastIndexOf('/'));
            string prlink2 = prlink.Substring(0, prlink.LastIndexOf('/'));

            this.initandcontent(prlink2);

            string req = this.cmipoxy(itemId, nodeId, lession, "Initialize", "");
            string sst = req.Substring(req.IndexOf("systime") + 9);
            sst = sst.Substring(0, 10);
            this.startStudyTime = sst;
            this.st = sst;
            int ct = int.Parse(this.st);
            int et = ct;
            et -= 60 * times;
            string data = "{\"cmi.learner_name\":\"" + this.username + "\",\"cmi.learner_id\":\"" + this.userID + "\",\"cmi.activity_title\":\"" + lession + "\",\"ulms.node_id\":" + nodeId + ",\"ulms.item_id\":" + itemId + ",\"startStudyTime\":" + this.st + ",\"systime\":" + et.ToString() + ",\"cmi.location\":\"" + startpage + "\",\"ulms.customized\":0,\"cmi.exit\":\"suspend\"}";
            //for (int i = 0; i < times && this.ssss; i++)
            //{
            //    string pg = this.loadpage(prlink + "/" + startpage, "");
            //    ct += 30 * i;
            //    string cts = ct.ToString() + "234";
            //    this.loadpage(prlink + "/" + startpage, "_=" + cts);

            //}

            this.cmipoxy(itemId, nodeId, lession, "Terminate", data);
            this.log = this.log + "完成";
            this.logTB.Text = this.log;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.studying)
            {
                this.studying = false;
                this.ssss = false;
                this.dataGridView1.Rows[0].Cells[2].Value = "等待中";
                this.button1.Text = "随机挂学时";
                this.button1.Enabled = false;
                //this.dataGridView2.Enabled = true;
                //this.dataGridView3.Enabled = true;
                //this.dataGridView4.Enabled = true;
                this.log = this.log + "\r\n" + "正在停止挂学时......";
                this.logTB.Text = this.log;
            }
            else
            {
                this.studying = true;
                this.ssss = true;
                this.dataGridView1.Rows[0].Cells[2].Value = "挂学时中";
                this.button1.Text = "停止挂学时";
                this.dataGridView2.Enabled = false;
                this.dataGridView3.Enabled = false;
                this.dataGridView4.Enabled = false;
                if (this.log == "")
                {
                    this.log = this.currentRows;
                }
                else
                {
                    this.log = this.log + "\r\n" + "当前选中的内容是：" + this.currentRows;
                }
                this.log = this.log + "\r\n" + "执行以下选中内容：" + this.currentRows;
                this.logTB.Text = this.log;

                Thread t1 = new Thread(new ThreadStart(tslalala2));
                t1.Start();
            }
        }

        public void tslalala2()
        {
            xsxsx xaa = new xsxsx(lalala2);
            this.Invoke(xaa);
        }

        public void lalala2()
        {
            int times = int.Parse(this.timeTB.Text);
            if (this.current == 4)
            {
                var rows = this.dataGridView4.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    string link = row.Cells[7].Value.ToString();
                    string itemId = row.Cells[8].Value.ToString();
                    string nodeId = row.Cells[9].Value.ToString();
                    string lession = row.Cells[0].Value.ToString();
                    string pn = row.Cells[2].Value.ToString();
                    if (this.ssss)
                    {
                        this.lululu2(itemId, nodeId, link, lession, pn, times);
                        //this.studyLession(itemId, nodeId, link, lession, pn, true);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (this.current == 3)
            {
                DataGridViewSelectedRowCollection rows = this.dataGridView3.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    string chapter = row.Cells[0].Value.ToString();
                    string data = row.Cells[5].Value.ToString();
                    string url = this.domain + this.genLessionUrl(data);
                    this.loadLessions(url);

                    this.log = this.log + "\r\n" + "章节：" + chapter;
                    this.logTB.Text = this.log;
                    int tttt = times;
                    if (chapter[0] != 'A' && chapter[0] != 'B' && chapter[0] != 'C')
                    {
                        tttt *= 1;
                    }
                    foreach (DataGridViewRow row2 in this.dataGridView4.Rows)
                    {
                        if (row2.Index == this.dataGridView4.RowCount - 1)
                        {
                            break;
                        }
                        string link = row2.Cells[7].Value.ToString();
                        string itemId = row2.Cells[8].Value.ToString();
                        string nodeId = row2.Cells[9].Value.ToString();
                        string lession = row2.Cells[0].Value.ToString();
                        string pn = row2.Cells[2].Value.ToString();
                        if (this.ssss)
                        {
                            this.lululu2(itemId, nodeId, link, lession, pn, tttt);
                            //this.studyLession(itemId, nodeId, link, lession, pn, true);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (!this.ssss)
                    {
                        break;
                    }
                    this.log = this.log + "\r\n" + "章节：" + chapter + " ······完成";
                    this.logTB.Text = this.log;
                }
            }
            else if (this.current == 2)
            {
                var rows = this.dataGridView2.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    string course = row.Cells[0].Value.ToString();
                    string url = this.domain + row.Cells[5].Value.ToString();

                    this.log = this.log + "\r\n" + "课程：" + course;
                    this.logTB.Text = this.log;

                    this.loadChapters(url);

                    DataGridViewRowCollection rows3 = this.dataGridView3.Rows;
                    foreach (DataGridViewRow row2 in rows3)
                    {
                        if (row2.Index == this.dataGridView3.RowCount - 1)
                        {
                            break;
                        }
                        string chapter = row2.Cells[0].Value.ToString();
                        string data = row2.Cells[5].Value.ToString();
                        string url2 = this.domain + this.genLessionUrl(data);
                        this.loadLessions(url2);

                        this.log = this.log + "\r\n" + "章节：" + chapter;
                        this.logTB.Text = this.log;
                        int tttt = times;
                        if (chapter[0] != 'A' && chapter[0] != 'B' && chapter[0] != 'C')
                        {
                            tttt *= 1;
                        }
                        foreach (DataGridViewRow row4 in this.dataGridView4.Rows)
                        {
                            if (row4.Index == this.dataGridView4.RowCount - 1)
                            {
                                break;
                            }
                            string link = row4.Cells[7].Value.ToString();
                            string itemId = row4.Cells[8].Value.ToString();
                            string nodeId = row4.Cells[9].Value.ToString();
                            string lession = row4.Cells[0].Value.ToString();
                            string pn = row4.Cells[2].Value.ToString();
                            if (this.ssss)
                            {
                                this.lululu2(itemId, nodeId, link, lession, pn, tttt);
                                //this.studyLession(itemId, nodeId, link, lession, pn, true);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (!this.ssss)
                        {
                            break;
                        }
                        this.log = this.log + "\r\n" + "章节：" + chapter + " ······完成";
                        this.logTB.Text = this.log;
                    }
                    if (!this.ssss)
                    {
                        break;
                    }
                    this.log = this.log + "\r\n" + "课程：" + course + " ······完成";
                    this.logTB.Text = this.log;
                }
            }
            this.studying = false;
            this.ssss = false;
            this.dataGridView2.Enabled = true;
            this.dataGridView3.Enabled = true;
            this.dataGridView4.Enabled = true;
            this.dataGridView1.Rows[0].Cells[2].Value = "等待中";
            this.log = this.log + "\r\n" + "完成挂学时";
            this.logTB.Text = this.log;
            this.button1.Text = "随机挂学时";
            this.button1.Enabled = true;
        }

        public void lululu2(string itemId, string nodeId, string link, string lession, string pn, int times)
        {
            this.log = this.log + "\r\n" + "开始挂学时：" + lession + "......";
            this.logTB.Text = this.log;
            this.heartbeat();

            string landingdata = this.landing(link);
            string startpage = landingdata.Substring(landingdata.LastIndexOf("startpage = ") + 13);
            startpage = startpage.Substring(0, startpage.IndexOf('\''));

            string prlink = link.Substring(0, link.IndexOf('?'));
            prlink = prlink.Substring(0, prlink.LastIndexOf('/'));
            string homepage = prlink.Substring(prlink.LastIndexOf('/'));
            string prlink2 = prlink.Substring(0, prlink.LastIndexOf('/'));

            this.initandcontent(prlink2);

            string req = this.cmipoxy(itemId, nodeId, lession, "Initialize", "");
            string sst = req.Substring(req.IndexOf("systime") + 9);
            sst = sst.Substring(0, 10);
            this.startStudyTime = sst;
            this.st = sst;
            int ct = int.Parse(this.st);
            int et = ct;
            int min = int.Parse(this.minTB.Text) * 60;
            int max = int.Parse(this.maxTB.Text) * 60;
            Random r = new Random();
            et -= r.Next(min, max);
            string data = "{\"cmi.learner_name\":\"" + this.username + "\",\"cmi.learner_id\":\"" + this.userID + "\",\"cmi.activity_title\":\"" + lession + "\",\"ulms.node_id\":" + nodeId + ",\"ulms.item_id\":" + itemId + ",\"startStudyTime\":" + this.st + ",\"systime\":" + et.ToString() + ",\"cmi.location\":\"" + startpage + "\",\"ulms.customized\":0,\"cmi.exit\":\"suspend\"}";
            //for (int i = 0; i < times && this.ssss; i++)
            //{
            //    string pg = this.loadpage(prlink + "/" + startpage, "");
            //    ct += 30 * i;
            //    string cts = ct.ToString() + "234";
            //    this.loadpage(prlink + "/" + startpage, "_=" + cts);

            //}

            this.cmipoxy(itemId, nodeId, lession, "Terminate", data);
            this.log = this.log + "完成";
            this.logTB.Text = this.log;
        }
    }
}
