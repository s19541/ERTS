import React from "react";
import { Table } from "react-bootstrap";
import { TournamentShortDto } from "../../../services/GeneratedClient";
import LolTournamentListTableRow from "./LolTournamentListTableRow";

function LolTournamentListTable(props: {
	tournamentList: TournamentShortDto[] | null;
	leagueId: number;
}) {
	const tournaments = props.tournamentList;
	const leagueId = props.leagueId;

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>Tournament</th>
					<th>Start Time</th>
					<th>End Time</th>
				</tr>
			</thead>
			<tbody>
				{tournaments?.map((tournament, i) => (
					<LolTournamentListTableRow
						tournament={tournament}
						leagueId={leagueId}
					/>
				))}
			</tbody>
		</Table>
	);
}

export default LolTournamentListTable;
