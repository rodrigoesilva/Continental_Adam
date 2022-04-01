using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental.Project.Adam.UI.HelperForms
{
    internal class Helper_AdamForm_LoadEval
    {
                //        //---------------------------------------------------------------------------
                //# include <vcl\vcl.h>
                //# include <time.h>
                //#pragma hdrstop

                //# include "Form_LoadEval.h"
                //# include "ExamDefinitions.h"
                //        //#include "Form_SQLScripts.h"
                //# include "Form_AskUserYesNo.h"
                //# include "Form_BackupGuide.h"
                //# include "Form_RestoreGuide.h"
                //# include "Form_SelectDir.h"
                //# include "Form_Main.h"
                //# include "Form_UserInfo.h"
                //# include "Form_ErrorMessage.h"
                //        //#include "Form_Progress.h"
                //        //---------------------------------------------------------------------------
                //#pragma link "Grids"
                //#pragma link "cCxComp_DBGrid"
                //#pragma link "cCxComp_Glyph_Button"
                //#pragma link "cCxComp_NState_Button"
                //#pragma link "cCxComp_Button"
                //#pragma link "ccxcomp_label"
                //#pragma link "cCxComp_3DFrame"
                //#pragma link "cCxComp_Grid"
                //#pragma link "cCxComp_Label"
                //#pragma link "cCxComp_TreeView"
                //#pragma link "cdiroutl"
                //#pragma link "PERFGRAP"
                //#pragma link "ccxcomp_checkbox"
                //#pragma resource "*.dfm"
                //#pragma package(smart_init)
                //        TFormLoadEval* FormLoadEval;


                //        //
                //        // (main) form class
                //        //


                //        void TFormLoadEval::HeaderDataToDialog(cDATABASE::sEXAMFILE::sHEADER* header)
                //        {
                //            EProduct1->Text = header->Product1;
                //            EProduct2->Text = header->Product2;
                //            ECustomer->Text = header->Customer;
                //            EProduct3->Text = header->Product3;
                //            EProduct4->Text = header->Product4;
                //            EIdent->Text = header->Ident;
                //            ETestingDate->Text = header->TestingDate;
                //            ETester->Text = header->Tester;
                //            LComment->CxLabel = header->Comment.c_str();
                //        }



                //        void TFormLoadEval::DialogToHeaderData(cDATABASE::sEXAMFILE* examfile)
                //        {
                //            examfile->header.Product1 = EProduct1->Text;
                //            examfile->header.Product2 = EProduct2->Text;
                //            examfile->header.Customer = ECustomer->Text;
                //            examfile->header.Product3 = EProduct3->Text;
                //            examfile->header.Product4 = EProduct4->Text;
                //            examfile->header.Ident = EIdent->Text;
                //            examfile->header.TestingDate = ETestingDate->Text;
                //            examfile->header.Tester = ETester->Text;
                //            examfile->header.Comment = LComment->CxLabel.c_str();
                //        }



                //        int __fastcall TFormLoadEval::ShowModal(cDATABASE::sEXAMFILE* examfile)
                //{
                //	TFormLoadEval::examfile = examfile;

                //	selected_entry = 0;

                //	HeaderDataToDialog(&(examfile->header));

                //	UpdateSQLSet();

                //        FrMain->CxBrightnessBoost = 0;

                //  TVExplorer->Color = clWindow;
                //  LVExplorer->Color = clWindow;

                //  CBMatchingOnly->Checked       = false;
                //  CBPrintSeries->Checked        = false;
                //  CBExportBitmapSeries->Checked = false;
                //  CBExportExcelSeries->Checked  = false;

                //	int rv = TForm::ShowModal();

                //	if (rv == mrOk
                //			|| rv == mrYes)												// +++
                //		DialogToHeaderData(examfile);

                //	return rv;
                //}



                //    __fastcall TFormLoadEval::TFormLoadEval(TComponent* Owner)
                //:
                //TForm(Owner),

                //no_lv_update(false)
                //    {
                //    }



                //    __fastcall TFormLoadEval::~TFormLoadEval(void)
                //    {
                //    }



                //    void TFormLoadEval::ClearTVExplorer(void)
                //    {
                //        // clear all entries
                //        TVExplorer->Items->Clear();
                //    }



                //    void TFormLoadEval::ClearLVExplorer(void)
                //    {
                //        // clear all entries
                //        LVExplorer->Items->Clear();
                //        LVExplorer->Columns->Clear();
                //    }



                //    void TFormLoadEval::ClearExplorers(void)
                //    {
                //        ClearTVExplorer();
                //        ClearLVExplorer();
                //    }



                //    int TFormLoadEval::UpdateSQLSet(void)
                //    {
                //        int result = 0;

                //        no_lv_update = true;

                //        TVExplorer->Items->BeginUpdate();

                //        try
                //        {
                //            FormUserInfo->Show("Einen Moment bitte, die Datenbank wird vorbereitet...");
                //            FormUserInfo->Repaint();

                //            // clear all explorer contents & corresp. data objects
                //            ClearExplorers();
                //            root_nodes.Empty();

                //            // "Search..."-button was pressed, then create "WHERE"-clauses for each non-empty header info
                //            AnsiString where_str = "";
                //            if (CBMatchingOnly->Checked)
                //            {
                //                int depth = 0;

                //#define _CREATE_WHERE_STR(_field)                                                                               \
                //                {                                                                                                               \
                //        if (strlen(E##_field->Text.Trim ().c_str ()) > 0)                                                            \
                //        {                                                                                                             \
                //          if (depth == 0)                                                                                             \
                //            where_str = AnsiString("(") + AnsiString( #_field ) + AnsiString ( " CONTAINS \"" ) + E##_field->Text.Trim () + AnsiString ( "\")" );                 \
                //          else                                                                                                        \
                //            where_str += AnsiString(" AND (") + AnsiString( #_field ) + AnsiString ( " CONTAINS \"" ) + E##_field->Text.Trim () + AnsiString ( "\")" );  \
                //                                                                                                                      \
                //          depth++;                                                                                                    \
                //        }                                                                                                             \
                //      }

                //                _CREATE_WHERE_STR(Ident)
                //              _CREATE_WHERE_STR(Customer)
                //              _CREATE_WHERE_STR(Product1)
                //              _CREATE_WHERE_STR(Product2)
                //              _CREATE_WHERE_STR(Product3)
                //              _CREATE_WHERE_STR(Product4)
                //              _CREATE_WHERE_STR(TestingDate)
                //              _CREATE_WHERE_STR(Tester)
                //            }

                //            // update database
                //            database.Directory()->Update();

                //            // 1. reset through all entry "_tag"s...
                //            cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry = database.Directory()->First();
                //            while (entry)
                //            {
                //                entry->_tag = false;

                //                entry = database.Directory()->Next();
                //            }

                //            // 2. create new tree
                //            int count = 0;
                //            while (1)
                //            {
                //                // 1. search the first un"_tag"ged entry (cause all "_tag"ged nodes are already in list)
                //                //
                //                entry = database.Directory()->First();

                //                while (entry)
                //                {
                //                    if (!entry->_tag)
                //                        break;

                //                    entry = database.Directory()->Next();
                //                }

                //                // if no further untagged entry remaining, everything has been done
                //                if (!entry)
                //                    break;

                //                // 2. create a new root-node at the corresp. alphabetical position
                //                //
                //                TTreeNode* node = TVExplorer->Items->Count ? TVExplorer->Items->Item[0] : 0;
                //                TTreeNode* parent_node = 0;

                //                while (node)
                //                {
                //                    if (stricmp(node->Text.c_str(), entry->header.Ident.c_str()) > 0)
                //                    {
                //                        parent_node = node;
                //                        break;
                //                    }

                //                    node = node->getNextSibling();
                //                }

                //                entry->_tag = true;

                //                TTreeNode* root_node = 0;
                //                if (!CBMatchingOnly->Checked
                //                    || ((strlen(EIdent->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Ident.c_str(), EIdent->Text.Trim().c_str()))
                //                        && (strlen(ECustomer->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Customer.c_str(), ECustomer->Text.Trim().c_str()))
                //                        && (strlen(EProduct1->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Product1.c_str(), EProduct1->Text.Trim().c_str()))
                //                        && (strlen(EProduct2->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Product2.c_str(), EProduct2->Text.Trim().c_str()))
                //                        && (strlen(EProduct3->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Product3.c_str(), EProduct3->Text.Trim().c_str()))
                //                        && (strlen(EProduct4->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Product4.c_str(), EProduct4->Text.Trim().c_str()))
                //                        && (strlen(ETestingDate->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.TestingDate.c_str(), ETestingDate->Text.Trim().c_str()))
                //                        && (strlen(ETester->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Tester.c_str(), ETester->Text.Trim().c_str()))))
                //                {
                //                    //        if (parent_node)
                //                    //          parent_node = parent_node->getNextSibling ();     // "Insert" appends BEFORE the parent node

                //                    root_node = TVExplorer->Items->Insert(parent_node, entry->header.Ident.c_str());

                //                    root_node->Data = (void*)0;
                //                    root_nodes << root_node;
                //                }

                //                // 3. create all child nodes from the entries with the same "Ident"
                //                //
                //                ctCX_BAG<cDATABASE_FILEDB::sDIRECTORY::sENTRY*> examtypes_bag;
                //                cCX_STRING root_ident = entry->header.Ident.c_str();
                //                while (entry)
                //                {
                //                    if (strcmp(root_ident.CStr(), entry->header.Ident.c_str()) == 0)
                //                    {
                //                        // if the "Ident" matches, mark it as "done"
                //                        entry->_tag = true;

                //                        if (root_node)
                //                        {
                //                            // check, if this examtype is already in list
                //                            cDATABASE_FILEDB::sDIRECTORY::sENTRY** obj_ref = examtypes_bag.First();
                //                            while (obj_ref)
                //                            {
                //                                if ((*obj_ref)->header.ExamType == entry->header.ExamType)
                //                                    break;

                //                                obj_ref = examtypes_bag.Next();
                //                            }

                //                            // if it's not in list yet, create a corresp. child node and add it to the list
                //                            if (!obj_ref)
                //                            {
                //                                TTreeNode* node = root_node->getFirstChild();
                //                                TTreeNode* parent_node = 0;

                //                                while (node)
                //                                {
                //                                    if (stricmp(node->Text.c_str(), sEXAMDEFS::ExamName(entry->header.ExamType)) > 0)
                //                                    {
                //                                        parent_node = node;
                //                                        break;
                //                                    }

                //                                    node = node->getNextSibling();
                //                                }

                //                                if (!parent_node)
                //                                    node = TVExplorer->Items->AddChild(root_node, sEXAMDEFS::ExamName(entry->header.ExamType));
                //                                else
                //                                    node = TVExplorer->Items->Insert(parent_node, sEXAMDEFS::ExamName(entry->header.ExamType));

                //                                node->Data = (void*)entry;
                //                                examtypes_bag << entry;
                //                            }

                //                            count++;
                //                        }
                //                    }

                //                    entry = database.Directory()->Next();
                //                }
                //            }

                //            result = count;
                //        }
                //        catch (...){ }

                //        no_lv_update = false;

                //        if (FormUserInfo->Visible)
                //            FormUserInfo->Close();

                //        TVExplorer->Items->EndUpdate();

                //        return result;
                //        }



                //        void __fastcall TFormLoadEval::BDeleteTestClick(TObject * Sender)
                //    {
                //            if (selected_entry
                //                    && FormAskUserYesNo->ShowModal(cPF_STRING("Are you sure to drop the selected test and all it´s measurement data?"),
                //                                              LVExplorer,
                //                                                                                  TFormAskUserYesNo::ADJ_COMPLETE) == mrYes)
                //            {
                //                database.DropExam(SelectedUniqueID());

                //                UpdateSQLSet();
                //            }
                //        }



                //        AnsiString & TFormLoadEval::BuildBackupDirName(void)
                //    {
                //            static AnsiString result;

                //            char buf[100];
                //            time_t t = time(NULL);

                //    struct tm * loctm = localtime(&t);
                //    sprintf(buf, "Conti_Backup_%.2d.%.2d.%.2d_%.2d.%.2d.%.2d", loctm->tm_mday, loctm->tm_mon + 1, (loctm->tm_year) % 100,
                //																														  loctm->tm_hour, loctm->tm_min, loctm->tm_sec);

                //	result = buf;
                //	return result;
                //}



                //void __fastcall TFormLoadEval::BBackupIdentClick(TObject *Sender)
                //{
                //    if (selected_entry)
                //    {
                //        FrMain->CxBrightnessBoost = -20;

                //        if (FormBackupGuide->ShowModal(FrExplorer,
                //                                                                        TFormAskUserYesNo::ADJ_COMPLETE) == cCXCOMP_BUTTON::MR_OK)
                //        {
                //            AnsiString dest_dir = FormBackupGuide->SelectedDir();
                //            dest_dir += AnsiString("\\");
                //            dest_dir += BuildBackupDirName();

                //            if (CreateDir(dest_dir))
                //            {
                //                // inform the user...
                //                AnsiString info_msg;

                //                info_msg = cPF_STRING("A backup of Ident # '");
                //                info_msg += selected_entry->header.Ident;
                //                info_msg += cPF_STRING("' will be stored to '");
                //                info_msg += dest_dir;
                //                info_msg += cPF_STRING("'...");

                //                FrExplorer->CxLabel = info_msg;
                //                FrExplorer->Update();

                //                // count entries for statistics
                //                cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry = database.Directory()->First();
                //                int n_o_rows = 0;
                //                while (entry)
                //                {
                //                    if (strcmp(entry->header.Ident.c_str(), selected_entry->header.Ident.c_str()) == 0)
                //                        n_o_rows++;

                //                    entry = database.Directory()->Next();
                //                }

                //                // perform backup process...
                //                entry = database.Directory()->First();

                //                unsigned int i = 1;
                //                bool copied_ok = true;
                //                while (entry
                //                       && copied_ok)
                //                {
                //                    ProgressBar->Position = (int)(((double)i) / n_o_rows * 1000);
                //                    ProgressBar->Update();
                //                    i++;

                //                    if (strcmp(entry->header.Ident.c_str(), selected_entry->header.Ident.c_str()) == 0)
                //                        copied_ok = copied_ok && database.BackupExam(entry->header.UniqueID, dest_dir);

                //                    entry = database.Directory()->Next();
                //                }

                //                if (!copied_ok)
                //                    FormErrorMessage->ShowModal(cPF_STRING("Backup Error! Maybe the destination directory does not exist or one of the files to backup already exist in the destination directory..."));

                //                UpdateSQLSet();
                //            }
                //        }

                //        FrMain->CxBrightnessBoost = 0;
                //    }
                //}



                //void __fastcall TFormLoadEval::BRestoreIdentClick(TObject *Sender)
                //{
                //    if (FormRestoreGuide->ShowModal(FrExplorer,
                //                                                                           TFormAskUserYesNo::ADJ_COMPLETE) == cCXCOMP_BUTTON::MR_OK
                //        && FormRestoreGuide->Directory())
                //    {
                //        cDATABASE_FILEDB::sDIRECTORY* directory = FormRestoreGuide->Directory();
                //        AnsiString src_dir = FormRestoreGuide->SelectedDir();

                //        // count entries for statistics
                //        cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry = directory->First();
                //        int n_o_rows = 0;
                //        while (entry)
                //        {
                //            if (strcmp(entry->header.Ident.c_str(), FormRestoreGuide->SelectedIdent().c_str()) == 0)
                //                n_o_rows++;

                //            entry = directory->Next();
                //        }

                //        // perform backup process...
                //        entry = directory->First();

                //        unsigned int i = 1;
                //        bool restored_ok = true;
                //        while (entry
                //               && restored_ok)
                //        {
                //            ProgressBar->Position = (int)(((double)i) / n_o_rows * 1000);
                //            ProgressBar->Update();
                //            i++;

                //            if (strcmp(entry->header.Ident.c_str(), FormRestoreGuide->SelectedIdent().c_str()) == 0)
                //                restored_ok = restored_ok && database.RestoreExam(entry->header.UniqueID, src_dir);

                //            entry = directory->Next();
                //        }

                //        if (!restored_ok)
                //            FormErrorMessage->ShowModal(cPF_STRING("Restore Error! Not all files have been restored correctly..."));

                //        UpdateSQLSet();
                //    }
                //}



                //void __fastcall TFormLoadEval::BRemoveIdentClick(TObject *Sender)
                //{
                //    if (selected_entry)
                //    {
                //        AnsiString tmp_question;

                //        tmp_question = cPF_STRING("Are you sure to drop Ident # '");
                //        tmp_question += selected_entry->header.Ident;
                //        tmp_question += cPF_STRING("' including all tests and their measurement data?");

                //        if (FormAskUserYesNo->ShowModal(tmp_question.c_str(),
                //                                                                         LVExplorer,
                //                                                                         TFormAskUserYesNo::ADJ_COMPLETE) == mrYes)
                //        {
                //            // count entries for statistics
                //            cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry = database.Directory()->First();
                //            int n_o_rows = 0;
                //            while (entry)
                //            {
                //                if (strcmp(entry->header.Ident.c_str(), selected_entry->header.Ident.c_str()) == 0)
                //                    n_o_rows++;

                //                entry = database.Directory()->Next();
                //            }

                //            // delete all entries with a matching "ident" from the database...
                //            entry = database.Directory()->First();

                //            unsigned int i = 1;
                //            while (entry)
                //            {
                //                ProgressBar->Position = (int)(((double)i) / n_o_rows * 1000);
                //                ProgressBar->Update();
                //                i++;

                //                if (strcmp(entry->header.Ident.c_str(), selected_entry->header.Ident.c_str()) == 0)
                //                    database.DropExam(entry->header.UniqueID);

                //                entry = database.Directory()->Next();
                //            }

                //            UpdateSQLSet();
                //        }
                //    }
                //}



                //void __fastcall TFormLoadEval::TVExplorerChange(TObject *Sender, TTreeNode *Node)
                //{
                //    if (no_lv_update)
                //        return;

                //    ClearLVExplorer();

                //    LVExplorer->Items->BeginUpdate();

                //#define BUILD_COL_EX(_caption)               \
                //    column = LVExplorer->Columns->Add();      \
                //    column->Caption = _caption;                \
                //    column->Width = ColumnTextWidth;

                //#define BUILD_COL(_item_type)                                                                                   \
                //    BUILD_COL_EX(cPF_STRING(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::_item_type].Caption()));  \

                //  try
                //    {
                //        selected_entry = (cDATABASE_FILEDB::sDIRECTORY::sENTRY*)(Node->Data);

                //        if (selected_entry)
                //        {
                //            // create new columns of the list-view
                //            TListColumn* column;

                //            BUILD_COL(IT_Customer)
                //          BUILD_COL(IT_TestingDate)
                //          BUILD_COL(IT_Product1)
                //          BUILD_COL(IT_Product2)
                //          BUILD_COL(IT_Product3)
                //          BUILD_COL(IT_Tester)
                //          BUILD_COL(IT_Product4)
                //          BUILD_COL(IT_Comment)

                //      cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry = database.Directory()->First();
                //            while (entry)
                //            {
                //                if (strcmp(entry->header.Ident.c_str(), selected_entry->header.Ident.c_str()) == 0
                //                    && entry->header.ExamType == selected_entry->header.ExamType
                //                    && (!CBMatchingOnly->Checked
                //                        || ((strlen(EIdent->Text.Trim().c_str()) == 0
                //                                || strstr(entry->header.Ident.c_str(), EIdent->Text.Trim().c_str()))
                //                            && (strlen(ECustomer->Text.Trim().c_str()) == 0
                //                                || strstr(entry->header.Customer.c_str(), ECustomer->Text.Trim().c_str()))
                //                            && (strlen(EProduct1->Text.Trim().c_str()) == 0
                //                                || strstr(entry->header.Product1.c_str(), EProduct1->Text.Trim().c_str()))
                //                            && (strlen(EProduct2->Text.Trim().c_str()) == 0
                //                                || strstr(entry->header.Product2.c_str(), EProduct2->Text.Trim().c_str()))
                //                            && (strlen(EProduct3->Text.Trim().c_str()) == 0
                //                                || strstr(entry->header.Product3.c_str(), EProduct3->Text.Trim().c_str()))
                //                            && (strlen(EProduct4->Text.Trim().c_str()) == 0
                //                                || strstr(entry->header.Product4.c_str(), EProduct4->Text.Trim().c_str()))
                //                            && (strlen(ETestingDate->Text.Trim().c_str()) == 0
                //                                || strstr(entry->header.TestingDate.c_str(), ETestingDate->Text.Trim().c_str()))
                //                            && (strlen(ETester->Text.Trim().c_str()) == 0
                //                                || strstr(entry->header.Tester.c_str(), ETester->Text.Trim().c_str())))))
                //                {
                //                    TListItem* list_item = LVExplorer->Items->Add();
                //                    list_item->Caption = entry->header.Customer;

                //                    switch (entry->header.DataType)
                //                    {
                //                        default:
                //                        case cDATABASE::sEXAMFILE::DT_UNKNOWN:
                //                            list_item->ImageIndex = 0;
                //                            break;
                //                        case cDATABASE::sEXAMFILE::DT_EXAM:
                //                            list_item->ImageIndex = 1;
                //                            break;
                //                        case cDATABASE::sEXAMFILE::DT_PURE_PARAMSET:
                //                            list_item->ImageIndex = 2;
                //                            break;
                //                    }

                //                    list_item->Data = (void*)entry;

                //                    list_item->SubItems->Add(entry->header.TestingDate);
                //                    list_item->SubItems->Add(entry->header.Product1);
                //                    list_item->SubItems->Add(entry->header.Product2);
                //                    list_item->SubItems->Add(entry->header.Product3);
                //                    list_item->SubItems->Add(entry->header.Tester);
                //                    list_item->SubItems->Add(entry->header.Product4);
                //                    list_item->SubItems->Add(entry->header.Comment);
                //                }

                //                entry = database.Directory()->Next();
                //            }
                //        }
                //    }
                //    catch (...) { }

                //    LVExplorer->AlphaSort();

                //    LVExplorer->Items->EndUpdate();
                //    }



                //    void __fastcall TFormLoadEval::FormDestroy(TObject * Sender)
                //{
                //        ClearExplorers();
                //    }



                //    void __fastcall TFormLoadEval::LVExplorerSelectItem(TObject * Sender, TListItem * Item, bool Selected)
                //{
                //        EIdent->Text = "";
                //        ECustomer->Text = "";
                //        ETestingDate->Text = "";
                //        EProduct1->Text = "";
                //        EProduct2->Text = "";
                //        EProduct3->Text = "";
                //        ETester->Text = "";
                //        EProduct4->Text = "";
                //        LComment->CxLabel = "";

                //        if (Selected)
                //        {
                //            selected_entry = (cDATABASE_FILEDB::sDIRECTORY::sENTRY*)(Item->Data);

                //            if (selected_entry)
                //            {
                //                EIdent->Text = selected_entry->header.Ident;

                //                if (strlen(selected_entry->header.UniqueID.c_str()) > 0)
                //                {
                //                    ECustomer->Text = selected_entry->header.Customer;

                //                    if (Item->SubItems->Count > 0)    // there will be the complete header info only if it's a leaf (Count > 0)
                //                        HeaderDataToDialog(&(selected_entry->header));
                //                }
                //            }
                //        }
                //        else
                //            selected_entry = 0;
                //    }



                //    AnsiString & TFormLoadEval::SelectedUniqueID(void)
                //{
                //        if (selected_entry)
                //            return selected_entry->header.UniqueID;

                //        static AnsiString error_result = "";
                //        return error_result;
                //    }



                //    eEXAMTYPE TFormLoadEval::SelectedExamType(void)
                //{
                //        if (selected_entry)
                //            return selected_entry->header.ExamType;

                //        return ET_NONE;
                //    }


                //    /*
                //    void TFormLoadEval::OpenBackupRestoreExpansion (void)
                //    {
                //        if (Height < designed_pos.dy)
                //            Height = designed_pos.dy;
                //    }



                //    void TFormLoadEval::CloseBackupRestoreExpansion (void)
                //    {
                //        if (Height == designed_pos.dy)
                //            Height -= LBackupRestoreFrame->Height;
                //    }
                //    */


                //    void __fastcall TFormLoadEval::FormCreate(TObject * Sender)
                //{
                //        designed_pos.x = Left;
                //        designed_pos.y = Top;
                //        designed_pos.dx = Width;
                //        designed_pos.dy = Height;
                //    }


                //    void __fastcall TFormLoadEval::CBMatchingOnlyClick(TObject * Sender)
                //{
                //        UpdateSQLSet();

                //        if (CBMatchingOnly->Checked)
                //        {
                //            TVExplorer->Color = 0x00A0FFFF;
                //            LVExplorer->Color = 0x00A0FFFF;
                //        }
                //        else
                //        {
                //            TVExplorer->Color = clWindow;
                //            LVExplorer->Color = clWindow;
                //        }
                //    }



                //    void __fastcall TFormLoadEval::BExportSeriesClick(TObject * Sender)
                //{
                //        if (CBPrintSeries->Checked
                //            || CBExportBitmapSeries->Checked
                //            || CBExportExcelSeries->Checked)
                //        {
                //            int count = UpdateSQLSet();

                //            bool dir_selected = false;
                //            if (CBExportBitmapSeries->Checked
                //                || CBExportExcelSeries->Checked)
                //                dir_selected = (FormSelectDir->ShowModal() == cCXCOMP_BUTTON::MR_OK);

                //            // 1. create a match-list, if nescessary
                //            ctCX_BAG<cDATABASE_FILEDB::sDIRECTORY::sENTRY*> match_list;

                //            if (CBMatchingOnly->Checked)
                //            {
                //                cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry = database.Directory()->First();
                //                while (entry)
                //                {
                //                    if ((strlen(EIdent->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Ident.c_str(), EIdent->Text.Trim().c_str()))
                //                        && (strlen(ECustomer->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Customer.c_str(), ECustomer->Text.Trim().c_str()))
                //                        && (strlen(EProduct1->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Product1.c_str(), EProduct1->Text.Trim().c_str()))
                //                        && (strlen(EProduct2->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Product2.c_str(), EProduct2->Text.Trim().c_str()))
                //                        && (strlen(EProduct3->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Product3.c_str(), EProduct3->Text.Trim().c_str()))
                //                        && (strlen(EProduct4->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Product4.c_str(), EProduct4->Text.Trim().c_str()))
                //                        && (strlen(ETestingDate->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.TestingDate.c_str(), ETestingDate->Text.Trim().c_str()))
                //                        && (strlen(ETester->Text.Trim().c_str()) == 0
                //                            || strstr(entry->header.Tester.c_str(), ETester->Text.Trim().c_str())))
                //                        match_list << entry;

                //                    entry = database.Directory()->Next();
                //                }
                //            }

                //            // 2. export all wanted data
                //            FormMain->BatchExport(CBMatchingOnly->Checked ? &match_list : &(database.Directory()->entrys),
                //                                   FormSelectDir->SelectedDir(),
                //                                   CBPrintSeries->Checked,
                //                                   dir_selected && CBExportExcelSeries->Checked,
                //                                   dir_selected && CBExportBitmapSeries->Checked);
                //        }
                //    }



                //    void __fastcall TFormLoadEval::LVExplorerCompare(TObject * Sender,
                //                                                      TListItem * Item1,
                //                                                      TListItem * Item2,
                //                                                      int Data,
                //                                                      int & Compare)
                //{
                //        cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry1 = (cDATABASE_FILEDB::sDIRECTORY::sENTRY*)(Item1->Data);
                //        cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry2 = (cDATABASE_FILEDB::sDIRECTORY::sENTRY*)(Item2->Data);

                //        Compare = -strcmp(entry1->header.UniqueID.c_str(), entry2->header.UniqueID.c_str());
                //    }
                //    //---------------------------------------------------------------------------

}
}
