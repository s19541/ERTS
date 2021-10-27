import { LolTournamentPlayerStatsDto } from "../../../../services/GeneratedClient";
import { useHistory } from "react-router";

function LolTournamentPlayerStatsListTableRow(props: {
	playerStats: LolTournamentPlayerStatsDto;
}) {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}

	const playerStats = props.playerStats;

	return (
		<tr>
			<td onClick={() => redirectToPage(`/lol/team/${playerStats.teamId}`)}
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				<img
					src={playerStats.teamImageUrl}
					className=""
					width={35}
					height={35}
				/>
			</td>
			<td
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				{playerStats.playerNick}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.kills}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.deaths}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.assists}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.kda}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.cs}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.csPerMinute}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.gold}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.goldPerMinute}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.killParticipation}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.damageShare}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.championsPlayed}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				<img
					src={playerStats.firstRecentChampionImageUrl}
					className=""
					width={35}
					height={35}
				/>
				<img
					src={playerStats.secondRecentChampionImageUrl}
					className=""
					width={35}
					height={35}
				/>
				<img
					src={playerStats.thirdRecentChampionImageUrl}
					className=""
					width={35}
					height={35}
				/>
			</td>
		</tr>
	);
}
export default LolTournamentPlayerStatsListTableRow;
