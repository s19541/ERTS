import { Table } from "react-bootstrap";
import { LolGamePlayerShortStatsDto } from "../../../../services/GeneratedClient";
import GamePlayerStatsTableRow from "./GamePlayerStatstableRow";

function GamePlayerStatsTable(props: {
	playerStatsList: LolGamePlayerShortStatsDto[] | undefined;
}) {
	const playerStatsList = props.playerStatsList;

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th
						style={{
							textAlign: "center",
						}}
					></th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						Nick
					</th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						KDA
					</th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						CS
					</th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						Gold
					</th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						Items
					</th>
				</tr>
			</thead>
			<tbody>
				{playerStatsList?.map((playerStats, i) => (
					<GamePlayerStatsTableRow playerStats={playerStats} />
				))}
			</tbody>
		</Table>
	);
}

export default GamePlayerStatsTable;
