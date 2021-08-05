import {
	TournamentShortDto,
	TournamentTeamShortDto,
} from "../../../../services/GeneratedClient";

function LolTournamentTeamTableRow(props: {
	position: number;
	tournamentTeam: TournamentTeamShortDto;
}) {
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
				{tournamentTeam.seriesWon}-{tournamentTeam.seriesLost}
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
export default LolTournamentTeamTableRow;
