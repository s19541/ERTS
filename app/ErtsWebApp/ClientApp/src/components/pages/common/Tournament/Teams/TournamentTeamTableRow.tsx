import {
	GameType,
	TournamentTeamShortDto,
} from "../../../../../services/GeneratedClient";
import { useHistory } from "react-router";

function TournamentTeamTableRow(props: {
	position: number;
	tournamentTeam: TournamentTeamShortDto;
}) {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}

	const position = props.position;
	const tournamentTeam = props.tournamentTeam;

	return (
		<tr>
			<td
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				{position}
			</td>
			<td
				style={{
					verticalAlign: "middle",
				}}
				onClick={() => redirectToPage(`/lol/team/${tournamentTeam.teamId}`)}
			>
				<img
					src={tournamentTeam.teamImageUrl}
					className=""
					width={50}
					height={50}
				/>
				{tournamentTeam.teamName}
			</td>
			<td
				style={{
					verticalAlign: "middle",
				}}
			>
				{tournamentTeam.matchesWon}-{tournamentTeam.matchesLost}
			</td>
			<td
				style={{
					verticalAlign: "middle",
				}}
			>
				{tournamentTeam.gamesWon}-{tournamentTeam.gamesLost}
			</td>
		</tr>
	);
}
export default TournamentTeamTableRow;
