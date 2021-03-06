﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmbASP4Unity.it.unical.mat.embasp.specializations.dlv
{
	using AnswerSet = it.unical.mat.embasp.languages.asp.AnswerSet;
	using AnswerSets = it.unical.mat.embasp.languages.asp.AnswerSets;

	public class DLVAnswerSets : AnswerSets
	{
		public DLVAnswerSets(string answerSets) : base(answerSets) { }

		public DLVAnswerSets(string @out, string err) : base(@out, err) { }

		protected internal override void Parse()
		{
			string pattern = ("\\{(.*)\\}");

      Regex regex = new Regex(@pattern);
      Match matcher = regex.Match(output);

      while (matcher.Success) {
				string answerSet = matcher.Value;
				string patternAnswerSet = ("(-?[a-z][A-Za-z0-9_]*(\\(.+?\\))?)(, |\\})");
        Regex regexAnswerSet = new Regex(patternAnswerSet);
        Match matcherAnswerSet = regexAnswerSet.Match(answerSet);
				IList<string> answerSetList = new List<string>();
				while (matcherAnswerSet.Success)
				{
					answerSetList.Add(matcherAnswerSet.Value);
          matcherAnswerSet = matcherAnswerSet.NextMatch();
        }
				answersets.Add(new AnswerSet(answerSetList));
        matcher = matcher.NextMatch();
      }
		}
	}
}