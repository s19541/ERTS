import { MatchDto } from "../../../services/GeneratedClient";

function LolMatchListTableRow(props: { match: MatchDto }) {
	const match = props.match;
	const startTime = match.startTime.format("HH:mm DD-MM-YYYY");
	var result = match.team1GamesWon + ":" + match.team2GamesWon;
	if (match.endTime == null) result = "vs";
	const winner = match.team1GamesWon > match.team2GamesWon ? "Blue" : "Red";
	const mode =
		winner == "Blue"
			? "BO" + (match.team1GamesWon * 2 - 1)
			: "BO" + (match.team2GamesWon * 2 - 1);

	return (
		<tr>
			<td
				style={{
					verticalAlign: "middle",
				}}
			>
				{startTime}
			</td>
			<td
				style={{
					textAlign: "right",
					verticalAlign: "middle",
				}}
			>
				{match.team1Acronym}
				<img src={match.team1ImageUrl} className="" width={50} height={50} />
			</td>
			<td
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				{result}
			</td>
			<td
				style={{
					verticalAlign: "middle",
				}}
			>
				<img src={match.team2ImageUrl} className="" width={50} height={50} />
				{match.team2Acronym}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{mode}
			</td>
		</tr>
	);
}
export default LolMatchListTableRow;
