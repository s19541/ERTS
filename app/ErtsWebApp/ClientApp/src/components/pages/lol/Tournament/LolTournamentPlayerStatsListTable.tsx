import React from "react";
import { Table } from "react-bootstrap";
import { LolTournamentPlayerStatsDto } from "../../../../services/GeneratedClient";
import LolTournamentPlayerStatsListTableRow from "./LolTournamentPlayerStatsListTableRow";

function LolTournamentPlayerStatsListTable(props: {
	playerStatsList: LolTournamentPlayerStatsDto[] | null;
}) {
	const playerStatsList = props.playerStatsList;

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th style={{ width: "3vh", textAlign: "center" }}>Team</th>
					<th style={{ width: "5vh", textAlign: "center" }}>Player</th>
					<th style={{ width: "5vh", textAlign: "center" }}>K</th>
					<th style={{ width: "5vh", textAlign: "center" }}>D</th>
					<th style={{ width: "5vh", textAlign: "center" }}>A</th>
					<th style={{ width: "5vh", textAlign: "center" }}>KDA</th>
					<th style={{ width: "5vh", textAlign: "center" }}>CS</th>
					<th style={{ width: "5vh", textAlign: "center" }}>CS/M</th>
					<th style={{ width: "5vh", textAlign: "center" }}>G</th>
					<th style={{ width: "5vh", textAlign: "center" }}>G/M</th>
					<th style={{ width: "5vh", textAlign: "center" }}>KP</th>
					<th style={{ width: "5vh", textAlign: "center" }}>DMGS</th>
					<th style={{ width: "5vh", textAlign: "center" }}>CP</th>
					<th style={{ width: "15vh", textAlign: "center" }}>Champs</th>
				</tr>
			</thead>
			<tbody>
				{playerStatsList?.map((playerStats, i) => (
					<LolTournamentPlayerStatsListTableRow playerStats={playerStats} />
				))}
			</tbody>
		</Table>
	);
}

export default LolTournamentPlayerStatsListTable;
