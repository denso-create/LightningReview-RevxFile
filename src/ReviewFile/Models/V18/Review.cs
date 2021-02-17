﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using LightningReview.ReviewFile.Models.V18.Defenitions;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class Review : EntityBase, IReview
    {
        #region プロパティ

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// すべての指摘
        /// </summary>
        public IEnumerable<IIssue> Issues
        {
	        get
	        {
		        var issues = new List<IIssue>();

		        // 各ドキュメントの指摘
		        foreach (var doc in Documents.List)
		        {
			        issues.AddRange(doc.AllIssues);
		        }

		        return issues.ToList();
	        }
        }

        IEnumerable<IDocument> IReview.Documents => Documents.List.OfType<IDocument>();

        #region 基本設定タブ
        
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Goal { get; set; }

        [XmlElement]
        public string EndCondition { get; set; }
        
        [XmlElement]
        public string Place { get; set; }

        
        [XmlElement]
        public Documents Documents { get; set; }
        
        /// <summary>
        /// ステータス
        /// TODO xmlの階層が深く取得が複雑となり、実装に時間がかかるため今後の課題とする
        /// 現時点ではデータ収集の対象になり得ないと考えられるため保留
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// ドメイン
        /// TODO xmlの階層が深く取得が複雑となり、実装に時間がかかるため今後の課題とする
        /// 現時点ではデータ収集の対象になり得ないと考えられるため保留
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// レビュー種別
        /// TODO xmlの階層が深く取得が複雑となり、実装に時間がかかるため今後の課題とする
        /// 現時点ではデータ収集の対象になり得ないと考えられるため保留
        /// </summary>
        public string ReviewType { get; set; }

        /// <summary>
        /// レビュー形式
        /// TODO xmlの階層が深く取得が複雑となり、実装に時間がかかるため今後の課題とする
        /// 現時点ではデータ収集の対象になり得ないと考えられるため保留
        /// </summary>
        public string ReviewStyle { get; set; }

        /// <summary>
        /// プロジェクト
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// プロジェクトコード
        /// </summary>
        public string ProjectCode
        {
	        get => Project.Code;
	        set => Project.Code = value;
        }

        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string ProjectName
        {
	        get => Project.Name;
	        set => Project.Name = value;
        }

        #endregion

        #region 予実タブ
        
        [XmlElement]
        public string PlannedDate { get; set; }

        [XmlElement]
        public string ActualDate { get; set; }

        [XmlElement]
        public string PlannedTime { get; set; }

        [XmlElement]
        public string ActualTime { get; set; }

        [XmlElement]
        public string Unit { get; set; }

        [XmlElement]
        public string PlannedScale { get; set; }

        [XmlElement]
        public string ActualScale { get; set; }

        [XmlElement]
        public string IssueCountOfGoal { get; set; }

        /// <summary>
        /// 実績件数
        /// </summary>
        public string IssueCountOfActual
        {
	        get
	        {
		        var issueCountOfActualCount = 0;
		        foreach (var issue in Issues)
		        {
                    // 指摘タイプがグッドポイントあるいは対策要否が否でない指摘の件数が実績件数
			        if ((issue.Type == "グッドポイント") || (issue.NeedToFix == "いいえ"))
			        {
                        continue;
			        }

			        issueCountOfActualCount++;
		        }

		        return issueCountOfActualCount.ToString();
	        }
        }

        #endregion

		#endregion
	}
}