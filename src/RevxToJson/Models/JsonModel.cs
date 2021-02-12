﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RevxToJsonService.Extensions;

namespace RevxToJsonService.Models
{
    /// <summary>
    /// JSONファイルのルートオブジェクト
    /// </summary>
    public class JsonModel
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public JsonModel()
        {

        }

        /// <summary>
        /// Revxのモデルからインスタンスを生成
        /// </summary>
        /// <param name="reviews"></param>
        public JsonModel(IEnumerable<LightningReview.RevxFile.Models.Review> reviews)
        {
            foreach ( var revModel in reviews)
            {
                var r = new Review(revModel);
                Reviews.Add(r);
            }
        }
        #endregion

        #region プロパティ

        /// <summary>
        /// レビュー数
        /// </summary>
        public int TotalReviewCount => Reviews.Count();

        /// <summary>
        /// すべてのレビューの総指摘件数
        /// </summary>
        public int TotalIssueCount {
            get {
                var i = 0;
                foreach ( var rev in Reviews)
                {
                    i += rev.Issues.Count();
                }

                return i;
            }
        }

        /// <summary>
        /// レビュー一覧
        /// </summary>
        public IList<Review> Reviews { get; }  = new List<Review>();

        #endregion
    }
}
