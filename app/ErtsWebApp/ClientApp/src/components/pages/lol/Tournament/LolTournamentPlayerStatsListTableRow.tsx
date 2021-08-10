import { LolTournamentPlayerStatsDto } from "../../../../services/GeneratedClient";

function LolTournamentPlayerStatsListTableRow(props: {
	playerStats: LolTournamentPlayerStatsDto;
}) {
	const playerStats = props.playerStats;

	return (
		<tr>
			<td
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
				{Math.round(
					((playerStats.kills + playerStats.assists) / playerStats.deaths) * 100
				) / 100}
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
				{playerStats.killParticipation * 100 + "%"}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.damageShare * 100 + "%"}
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
