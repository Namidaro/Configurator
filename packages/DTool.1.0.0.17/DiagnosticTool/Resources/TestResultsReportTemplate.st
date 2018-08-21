<body>
<style>
table{border: 1px solid #000000;border-collapse: collapse;margin: 5px;width: 99%;}
td{border: 1px solid #000000;padding:5px;}
tr.package{background-color:rgb(8,111,158); color:white;}
td.testName{width:30%;}
td.testResult{width:15%;}
td.testDescription{width:30%;}
td.category{background-color:rgb(65,177,225);}
td.header{background-color:rgb(207,236,248);}
</style>

<h2>Test Results</h2>
	<h3>Date: $Model.ReportDate$</h3>

	$Model.TestsGroupResult:{ testGroup |
	<h3>$testGroup.Key$</h3>	
	
	$testGroup.SubGroups:{ subgroup |
	<table>
		<tr class="package">
			<td>$subgroup.Key$</td>
		</tr>
		<tr>
			<td>
			$subgroup.SubGroups: { category |
				<table>
					<tr>
						<td colspan="4" class="category">$category.Key$</td>
					</tr>
					<tr>
						<td class="testName header">Test Name</td>
						<td class="testResult header">Result</td>
						<td class="testDescription header">Description</td>
						<td class="header">Error Code</td>
					</tr>
					$category.Items: { test |
						<tr>
							<td class="testName">$test.Name$</td>
							<td class="testResult">$test.Result$</td>
							<td class="testDescription">$test.Description$</td>
							<td>$if(test.Unsuccessful)$ $test.ErrorCode$ $endif$</td>
						</tr>
					}$
				</table>
			}$
			</td>
		</tr>
	</table>
	}$
		
}$
	
</body>