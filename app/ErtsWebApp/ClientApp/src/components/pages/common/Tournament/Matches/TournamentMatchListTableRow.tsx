import { MatchShortDto } from "../../../../../services/GeneratedClient";
import { useHistory } from "react-router";

interface IProps {
	match: MatchShortDto;
	gameType: string;
}

const TournamentMatchListTableRow: React.FunctionComponent<IProps> = (props) => {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		if (gameType == "lol")
			history.push(page);
	}
	const match = props.match;
	const gameType = props.gameType;
	const startTime = match.startTime?.format("HH:mm DD-MM-YYYY");
	var result = match.team1GamesWon + ":" + match.team2GamesWon;
	if (match.endTime == null)
		result = "vs";

	const mode = "BO" + match.numberOfGames;

	return (
		<tr onClick={() => redirectToPage(`/lol/match/${match.id}`)}>
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
export default TournamentMatchListTableRow;
