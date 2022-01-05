import { Table } from "react-bootstrap";
import { LolTournamentTeamStatsDto } from "../../../../services/GeneratedClient";
import LolTournamentTeamStatsListTableRow from "./LolTournamentTeamStatsListTableRow";
import { useTranslation } from "react-i18next";

interface IProps {
    teamStatsList: LolTournamentTeamStatsDto[] | null;
}

const LolTournamentTeamStatsListTable: React.FunctionComponent<IProps> = (props) => {
    const teamStatsList = props.teamStatsList;
    const { t } = useTranslation();

    return (
        <Table striped bordered hover variant="dark">
            <thead>
                <tr>
                    <th style={{ width: "5vh", textAlign: "center" }}>{t("tournament.lol.team-stats.team")}</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>K</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>D</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>A</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>{t("tournament.lol.team-stats.gold")}</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>{t("tournament.lol.team-stats.dragons")}</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>{t("tournament.lol.team-stats.heralds")}</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>{t("tournament.lol.team-stats.barons")}</th>
                    <th style={{ width: "5vh", textAlign: "center" }}>{t("tournament.lol.team-stats.towers")}</th>
                    <th style={{ width: "20vh", textAlign: "center" }}>{t("tournament.lol.team-stats.champs")}</th>
                </tr>
            </thead>
            <tbody>
                {teamStatsList?.map((teamStats, i) => (
                    <LolTournamentTeamStatsListTableRow teamStats={teamStats} />
                ))}
            </tbody>
        </Table>
    );
}

export default LolTournamentTeamStatsListTable;